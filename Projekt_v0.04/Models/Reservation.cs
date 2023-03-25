using System;
using System.Threading.Tasks;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.Services.ReservationCreators;

namespace Projekt_v0._04.Models;

public class Reservation
{
    public string miasto;
    public string hotel;
    public string przydzielonyPokoj;
    public int liczbaWszystkichPokoi;
    public string użytkownik;
    public DateTime dataPrzyjazdu;
    public DateTime dataWyjazdu;
    public bool rezerwacjaPotwierdzona;
    private IReservationCreator reservationCreator;
    private const string CONNECTION_STRING = 
        "stąd zostały usunięte dane do logowania do bazy danych";
    public Reservation()
    {
        dataPrzyjazdu = DateTime.Today;
        dataWyjazdu = DateTime.Today.AddDays(7);
        ProjektDbContextFactory projektDbContextFactory = new ProjektDbContextFactory(CONNECTION_STRING);
        reservationCreator = new DatabaseReservationCreator(projektDbContextFactory);
        rezerwacjaPotwierdzona = false;
    }
    public int CheckForFirstFreeRoom(Reservation reservation)
    {
        return reservationCreator.CheckForFirstFreeRoom(reservation);
    }
    public async Task AddReservation(Reservation reservation)
    { 
        await reservationCreator.CreateReservation(reservation);
    }
}