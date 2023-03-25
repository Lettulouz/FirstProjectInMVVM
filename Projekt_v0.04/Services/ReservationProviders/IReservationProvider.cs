using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.ReservationProviders;

public interface IReservationProvider
{
    List<Reservations> GetAllReservations();
    List<Reservations> GetAllReservationsByUser(string uzytkownik);
    List<Reservations> GetAllReservationsByHotel(string hotel);
}