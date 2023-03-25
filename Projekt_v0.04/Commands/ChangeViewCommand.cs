using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using Projekt_v0._04.Exceptions;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;
using Projekt_v0._04.ViewModels;

namespace Projekt_v0._04.Commands;

public class ChangeViewCommand : AsyncCommandBase
{
    private readonly LoginViewModel _loginViewModel;
    private readonly NavigationService _navigationService;
    private readonly App app;
    private readonly Browser _browser;
    private readonly Login _login;
    private readonly HotelsBrowser _hotelsBrowser;
    private readonly HotelInfo _hotelInfo;
    private readonly Reservation _reservation;
    private readonly ShowReservationsViewModel _showReservationsViewModel;
    private string _loggedUser, _hotel;
    public ChangeViewCommand(NavigationService navigationService, Login login)
    {
        _navigationService = navigationService;
        _login = login;
    }
    public ChangeViewCommand(NavigationService navigationService, Login login, ShowReservationsViewModel showReservationsViewModel)
    {
        _navigationService = navigationService;
        _login = login;
        _showReservationsViewModel = showReservationsViewModel;
    }
    public ChangeViewCommand(NavigationService navigationService, Login login, HotelsBrowser hotelsBrowser)
    {
        _hotelsBrowser = hotelsBrowser;
        _navigationService = navigationService;
        _login = login;
    }
    public ChangeViewCommand(NavigationService navigationService, Login login, HotelsBrowser hotelsBrowser, HotelInfo hotelInfo)
    {
        _hotelInfo = hotelInfo;
        _hotelsBrowser = hotelsBrowser;
        _navigationService = navigationService;
        _login = login;
    }
    public ChangeViewCommand(NavigationService navigationService, Login login, HotelsBrowser hotelsBrowser, HotelInfo hotelInfo, Reservation reservation)
    {
        _hotelInfo = hotelInfo;
        _hotelsBrowser = hotelsBrowser;
        _navigationService = navigationService;
        _login = login;
        _reservation = reservation;
    }
    public ChangeViewCommand(LoginViewModel loginViewModel, NavigationService navigationService, Login login)
    {
        _loginViewModel = loginViewModel;
        _navigationService = navigationService;
        _login = login;
        _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }
    public ChangeViewCommand(NavigationService navigationService, Browser browser, Login login)
    {
        _navigationService = navigationService;
        _browser = browser;
        _login = login;
    }

    public override bool CanExecute(object parameter)
    {
        switch(parameter)
        {
            case "Zarejestruj":
                return !string.IsNullOrEmpty(_login._loginUsername) &&
                       !string.IsNullOrEmpty(_login._loginPassword) &&
                       base.CanExecute(parameter);
            case "Zaloguj":
                return !string.IsNullOrEmpty(_login._loginUsername) &&
                       !string.IsNullOrEmpty(_login._loginPassword) &&
                       base.CanExecute(parameter);
            case "PrzejdzDoRezerwacji":
                return Int32.Parse(_hotelInfo.WolnePokoje) != 0 &&
                       base.CanExecute(parameter);
            case "AdminPotwierdźRezerwację":
                if (_login._loggedUser == "Admin")
                    return true;
                string myConnectionString=
                    "stąd zostały usunięte dane do logowania do bazy danych";
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM allhotels WHERE NazwaHotelu = @NazwaHotelu" , conn);
                conn.Open();
                check_User_Name.Parameters.AddWithValue("@NazwaHotelu", _login._loggedUser);
                var UserExist = check_User_Name.ExecuteScalar();
                if (UserExist == null)
                    return false; 
                else
                    return true;
            default:
                return base.CanExecute(parameter);
        }
    }

    public override async Task ExecuteAsync(object parameter)
    {
        switch (parameter)
        {
            case "Glowna":
                _navigationService.Navigate(new MainBrowserViewModel(_navigationService, _login));
                break;
            case "Szukaj":
                _browser.CheckIfSelectedCityIsValid();
                _navigationService.Navigate(new HotelsBrowserViewModel(_navigationService,_browser, _login));
                break;
            case "ONas":
                _navigationService.Navigate(new AboutUsViewModel(_navigationService, _login));
                break;
            case "Logowanie":
                _navigationService.Navigate(new LoginViewModel(_navigationService, _login));
                break;
            case "Zarejestruj":
                try
                {
                    await _login.CreateAccount(_login);
                }
                catch (RegisterConflictException)
                {
                    MessageBox.Show("Takie konto juz istnieje.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się zarejestrować.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                break;
            case "Zaloguj":
                await _login.CheckIfAccountExists(_login);
                if(_login.AccountExists())
                    _navigationService.Navigate(new ShowReservationsViewModel(_navigationService, _login));
                break;
            case "WybierzHotel1": case "WybierzHotel2": case "WybierzHotel3":
                _navigationService.Navigate(new HotelInfoViewModel(_navigationService, _login, parameter.ToString(), _hotelsBrowser));
                break;
            case "PrzejdzDoRezerwacji":
                if (_login._loginUsername == "Gość")
                {
                    MessageBox.Show("Najpierw się zaloguj.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    _navigationService.Navigate(new LoginViewModel(_navigationService, _login));
                }
                else
                    _navigationService.Navigate(new ReservationViewModel(_navigationService , _login, _hotelsBrowser, _hotelInfo));
                break;
            case "PotwierdzamRezerwację":
                await _reservation.AddReservation(_reservation);
                _navigationService.Navigate(new ReservationSumUpViewModel(_navigationService , _login, _reservation));
                break;
            case "AdminPotwierdźRezerwację":
                await _showReservationsViewModel._showReservations.UpdateReservation(_showReservationsViewModel.SelectedItem.ID);
                _showReservationsViewModel.setToTrue();
                break;
            case "Wyjscie":
                App.Current.Shutdown();
                break;
            default:
                _navigationService.Navigate(new MainBrowserViewModel(_navigationService, _login));
                break;
        }
    }
    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(LoginViewModel.LoginUsername) ||
            e.PropertyName == nameof(LoginViewModel.LoginPassword))
        {
            OnCanExecuteChanged();
        }
    }
}