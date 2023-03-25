using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;

namespace Projekt_v0._04.ViewModels;

public class ReservationViewModel : ViewModelBase
{
    private HotelsBrowser _hotelsBrowser;
    private HotelInfo _hotelInfo;
    private Reservation reservation = new Reservation();
    private Login _login;

    public string LoggedUser
    {
        get
        {
            return _login._loggedUser;
        }
    }
    public DateTime DataPrzyjazdu
    {
        get
        {
            return reservation.dataPrzyjazdu;
        }
        set
        {
            reservation.dataPrzyjazdu = value;
            if(DataPrzyjazdu < DateTime.Today)
                DataPrzyjazdu = DateTime.Today;
            if (DataPrzyjazdu >= DataWyjazdu)
                DataWyjazdu = DataPrzyjazdu.AddDays(1);
            reservation.przydzielonyPokoj = reservation.CheckForFirstFreeRoom(reservation).ToString();
            OnPropertyChanged(nameof(DataPrzyjazdu));
            OnPropertyChanged(nameof(PrzydzielonyPokoj));
        }
    }
    public DateTime DataWyjazdu
    {
        get
        {
            return reservation.dataWyjazdu;
        }
        set
        {
            reservation.dataWyjazdu = value;
            if (DataWyjazdu == DateTime.Today)
                DataWyjazdu = DateTime.Today.AddDays(1);
            if(DataWyjazdu < DateTime.Today.AddDays(1))
                DataWyjazdu = DateTime.Today.AddDays(1);
            if (DataWyjazdu <= DataPrzyjazdu)
                DataPrzyjazdu = DataWyjazdu.AddDays(-1);
            reservation.przydzielonyPokoj = reservation.CheckForFirstFreeRoom(reservation).ToString();
            OnPropertyChanged(nameof(DataWyjazdu));
            OnPropertyChanged(nameof(PrzydzielonyPokoj));
        }
    }

    public string PrzydzielonyPokoj
    {
        get
        {
            return reservation.przydzielonyPokoj;
        }
        set
        {
            
        }
    }
    public ICommand ChangeViewCommand { get; }
    
    public ReservationViewModel(NavigationService navigationService, Login login, HotelsBrowser hotelsBrowser, HotelInfo hotelInfo)
    {
        _hotelsBrowser = hotelsBrowser;
        _login = login;
        _hotelInfo = hotelInfo;
        switch (hotelInfo.WybranyHotel)
        {
            case 1:
                reservation.liczbaWszystkichPokoi = Int32.Parse(hotelsBrowser.WszystkiePokoje1);
                reservation.hotel = hotelsBrowser.NazwaHotelu1; 
                reservation.przydzielonyPokoj = reservation.CheckForFirstFreeRoom(reservation).ToString();
                break;
            case 2:
                reservation.liczbaWszystkichPokoi = Int32.Parse(hotelsBrowser.WszystkiePokoje2);
                reservation.hotel = hotelsBrowser.NazwaHotelu2;
                reservation.przydzielonyPokoj = reservation.CheckForFirstFreeRoom(reservation).ToString();
                break;
            case 3:
                reservation.liczbaWszystkichPokoi = Int32.Parse(hotelsBrowser.WszystkiePokoje3);
                reservation.hotel = hotelsBrowser.NazwaHotelu3;
                reservation.przydzielonyPokoj = reservation.CheckForFirstFreeRoom(reservation).ToString();
                break;
        }

        reservation.miasto = hotelsBrowser.SelectedCity;
        reservation.użytkownik = LoggedUser;
        ChangeViewCommand = new ChangeViewCommand(navigationService, _login, _hotelsBrowser, _hotelInfo, reservation);
    }
}