using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MySqlConnector;
using Projekt_v0._04.Commands;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;
using Projekt_v0._04.Services.ReservationProviders;
using Projekt_v0._04.Stores;
using Projekt_v0._04.ViewModels;

namespace Projekt_v0._04.ViewModels;

public class ShowReservationsViewModel : ViewModelBase
{
    private const string CONNECTION_STRING = 
        "stąd zostały usunięte dane do logowania do bazy danych";
    public readonly IReservationProvider _reservationProvider;
    private readonly NavigationService _navigationService;
    public readonly Login _login;
    public readonly ShowReservations _showReservations = new ShowReservations();
    public ICommand ChangeViewCommand { get; }
    public List<Reservations> ReservationsList;

    private Reservations reservation;
    public Reservations SelectedItem
    {
        get
        {
            return reservation;
        }
        set
        {
            reservation  = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }
    public List<Reservations> ReservationsListShow
    {
        get
        {
            return ReservationsList;
        }
        set
        {
            ReservationsList = value;
        }
        
    }
    public ShowReservationsViewModel(NavigationService navigationService, Login login)
    {
        _navigationService = navigationService;
        _login = login;
        ProjektDbContextFactory projektDbContextFactory = new ProjektDbContextFactory(CONNECTION_STRING);
        _reservationProvider = new DatabaseReservationProvider(projektDbContextFactory);
        setToTrue();
        ChangeViewCommand = new ChangeViewCommand(navigationService, login, this);
    }

    public void setToTrue()
    {
        if(_login._loggedUser == "Admin")
            ReservationsList = _reservationProvider.GetAllReservations();
        else
        {
            string myConnectionString=
                "server=mysql26.mydevil.net;port=3306;user=m1428_pudzian;password=Admin123*;database=m1428_polskagurom";
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM allhotels WHERE NazwaHotelu = @NazwaHotelu" , conn);
            conn.Open();
            check_User_Name.Parameters.AddWithValue("@NazwaHotelu", _login._loggedUser);
            var UserExist = check_User_Name.ExecuteScalar();
            if (UserExist == null)
                ReservationsList = _reservationProvider.GetAllReservationsByUser(_login._loggedUser);
            else
                ReservationsList = _reservationProvider.GetAllReservationsByHotel(_login._loggedUser);
        }

        OnPropertyChanged(nameof(ReservationsListShow));
    }
}