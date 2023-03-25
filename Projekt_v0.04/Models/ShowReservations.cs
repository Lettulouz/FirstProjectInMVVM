using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.Services.ReservationCreators;

namespace Projekt_v0._04.Models;

public class ShowReservations
{
    public List<Reservation> Reservations;
    private IReservationCreator reservationCreator;
    private const string CONNECTION_STRING = 
        "stąd zostały usunięte dane do logowania do bazy danych";

    public ShowReservations()
    {
        ProjektDbContextFactory projektDbContextFactory = new ProjektDbContextFactory(CONNECTION_STRING);
        reservationCreator = new DatabaseReservationCreator(projektDbContextFactory);
    }
    
    public async Task UpdateReservation(string ID)
    {
        await reservationCreator.UpdateReservation(ID);
    }

}