using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Projekt_v0._04.Commands;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.DTOs;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.ReservationCreators;

public class DatabaseReservationCreator : IReservationCreator
{
    private readonly ProjektDbContextFactory _dbContextFactory;
    string myConnectionString=
        "stąd zostały usunięte dane do logowania do bazy danych";
    private MySqlConnection connection;

    public DatabaseReservationCreator(ProjektDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task CreateReservation(Reservation reservation)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            ReservationDTO reservationDto = ToReservationDTO(reservation);

            context.Reservations.Add(reservationDto);

           await context.SaveChangesAsync();
        }
    }

    public async Task UpdateReservation(string ID)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            ReservationDTO reservationDto = await context.Reservations.FirstOrDefaultAsync(r => r.ID.ToString() == ID);
            reservationDto.RezerwacjaPotwierdzona = true;
            
            await context.SaveChangesAsync();
        }
    }


    public int CheckForFirstFreeRoom(Reservation reservation)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            List<int> wolnePokoje = new List<int>(); 
            List<int> wszystkiePokoje = new List<int>(); 
            for (int i = 1; i <= reservation.liczbaWszystkichPokoi; i++)
            {
                wszystkiePokoje.Add(i);
            }
            List<int> reservationDto = context.Reservations
                .Where(r => r.DataPrzyjazdu < reservation.dataWyjazdu && r.DataWyjazdu > reservation.dataPrzyjazdu && r.Hotel == reservation.hotel)
                .Select(r => r.NumerPokoju)
                .ToList();
            if (reservationDto.Count == 0)
            {
                return 1;
            }
            wolnePokoje = wszystkiePokoje.Except(reservationDto).ToList();
            wolnePokoje.Sort();
            int pokojDoPrzydzielenia = wolnePokoje[0];
            return pokojDoPrzydzielenia;
        }
    }

    private ReservationDTO ToReservationDTO(Reservation reservation)
    {
        return new ReservationDTO()
        {
            NumerPokoju = Int32.Parse(reservation.przydzielonyPokoj),
            Miasto = reservation.miasto,
            Hotel = reservation.hotel,
            Użytkownik = reservation.użytkownik,
            DataPrzyjazdu = reservation.dataPrzyjazdu,
            DataWyjazdu = reservation.dataWyjazdu,
            RezerwacjaPotwierdzona = reservation.rezerwacjaPotwierdzona
        };
    }
}