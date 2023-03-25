using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.DTOs;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.ReservationProviders;

public class DatabaseReservationProvider : IReservationProvider
{
    private readonly ProjektDbContextFactory _dbContextFactory;

    public DatabaseReservationProvider(ProjektDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    
    public List<Reservations> GetAllReservations()
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            List<Reservations> lstOfReservations = new List<Reservations>();
            Reservations reservation;
            List<ReservationDTO> reservationDtos =  context.Reservations.ToList();
            if (reservationDtos.Count != null)
            {
                for (int i = 0; i < reservationDtos.Count; i++)
                {
                    reservation = new Reservations(reservationDtos.ElementAt(i).Miasto, reservationDtos.ElementAt(i).Hotel,
                        reservationDtos.ElementAt(i).NumerPokoju.ToString(), 
                        reservationDtos.ElementAt(i).Użytkownik,
                        reservationDtos.ElementAt(i).DataPrzyjazdu,
                        reservationDtos.ElementAt(i).DataWyjazdu, reservationDtos.ElementAt(i).RezerwacjaPotwierdzona,
                        reservationDtos.ElementAt(i).ID.ToString());
                    lstOfReservations.Add(reservation);
                }
            }
            return lstOfReservations;
        }
    }
    
    public List<Reservations> GetAllReservationsByUser(string uzytkownik)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            List<Reservations> lstOfReservations = new List<Reservations>();
            Reservations reservation;
            List<ReservationDTO> reservationDtos =  context.Reservations.Where(r => r.Użytkownik == uzytkownik).ToList();
            if (reservationDtos.Count != null)
            {
                for (int i = 0; i < reservationDtos.Count; i++)
                {
                    reservation = new Reservations(reservationDtos.ElementAt(i).Miasto, reservationDtos.ElementAt(i).Hotel,
                        reservationDtos.ElementAt(i).NumerPokoju.ToString(), 
                        reservationDtos.ElementAt(i).Użytkownik,
                        reservationDtos.ElementAt(i).DataPrzyjazdu,
                        reservationDtos.ElementAt(i).DataWyjazdu, reservationDtos.ElementAt(i).RezerwacjaPotwierdzona,
                        reservationDtos.ElementAt(i).ID.ToString());
                    lstOfReservations.Add(reservation);
                }
            }
            return lstOfReservations;
        }
    }
    
    public List<Reservations> GetAllReservationsByHotel(string hotel)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            List<Reservations> lstOfReservations = new List<Reservations>();
            Reservations reservation;
            List<ReservationDTO> reservationDtos =  context.Reservations.Where(r => r.Hotel == hotel).ToList();
            if (reservationDtos.Count != null)
            {
                for (int i = 0; i < reservationDtos.Count; i++)
                {
                    reservation = new Reservations(reservationDtos.ElementAt(i).Miasto, reservationDtos.ElementAt(i).Hotel,
                        reservationDtos.ElementAt(i).NumerPokoju.ToString(), 
                        reservationDtos.ElementAt(i).Użytkownik,
                        reservationDtos.ElementAt(i).DataPrzyjazdu,
                        reservationDtos.ElementAt(i).DataWyjazdu, reservationDtos.ElementAt(i).RezerwacjaPotwierdzona,
                        reservationDtos.ElementAt(i).ID.ToString());
                        lstOfReservations.Add(reservation);
                }
            }
            return lstOfReservations;
        }
    }
}