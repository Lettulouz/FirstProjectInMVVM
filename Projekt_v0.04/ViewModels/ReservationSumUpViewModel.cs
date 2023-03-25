using System;
using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;

namespace Projekt_v0._04.ViewModels;

public class ReservationSumUpViewModel : ViewModelBase
{
    private Login _login;
    public ReservationSumUp _reservationSumUp = new ReservationSumUp();
    
    public string LoggedUser
    {
        get
        {
            return _login._loggedUser;
        }
    }

    public string ReservationSumUpMessage
    {
        get
        {
            return _reservationSumUp.ReservationSumUpMessage;
        }
    }

    public string Miasto
    {
        get
        {
            return _reservationSumUp.Miasto;
        }
    }

    public string Hotel
    {
        get
        {
            return _reservationSumUp.Hotel;
        }
    }

    public string User
    {
        get
        {
            return _reservationSumUp.User;
        }
    }

    public string RezerwowanyPokoj
    {
        get
        {
            return _reservationSumUp.RezerwowanyPokoj;
        }
    }

    public string DataPrzyjazdu
    {
        get
        {
            return _reservationSumUp.DataPrzyjazdu;
        }
    }

    public string DataWyjazdu
    {
        get
        {
            return _reservationSumUp.DataWyjazdu;
        }
    }
    public ICommand ChangeViewCommand { get; }
    
    public ReservationSumUpViewModel(NavigationService viewNavigationService, Login login, Reservation reservation)
    {
        _login = login;
        _reservationSumUp.User = reservation.użytkownik;
        _reservationSumUp.RezerwowanyPokoj = reservation.przydzielonyPokoj;
        _reservationSumUp.DataPrzyjazdu = reservation.dataPrzyjazdu.ToShortDateString();
        _reservationSumUp.DataWyjazdu = reservation.dataWyjazdu.ToShortDateString();
        _reservationSumUp.Miasto = reservation.miasto;
        _reservationSumUp.Hotel = reservation.hotel;
        
        ChangeViewCommand = new ChangeViewCommand(viewNavigationService, _login);
    }
}