using System.Threading.Tasks;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.ReservationCreators;

public interface IReservationCreator
{
    Task CreateReservation(Reservation reservation);
    Task UpdateReservation(string ID);
    int CheckForFirstFreeRoom(Reservation reservation);
}