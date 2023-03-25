using System;
using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;

namespace Projekt_v0._04.ViewModels;

public class HotelInfoViewModel : ViewModelBase
{
    private Login _login;
    private HotelInfo _hotelInfo = new HotelInfo();
    private readonly HotelsBrowser _hotelsBrowser;
    
    
    public string Zdjecie
    {
        get
        {
            return _hotelInfo.Zdjecie;
        }
    }
    public string NazwaHotelu
    {
        get
        {
            return _hotelInfo.NazwaHotelu;
        }
    }
    public string Atrybut2
    {
        get
        {
            return _hotelInfo.Atrybut2;
        }
    }
    public string Atrybut3
    {
        get
        {
            return _hotelInfo.Atrybut3;
        }
    }
    public string Atrybut4
    {
        get
        {
            return _hotelInfo.Atrybut4;
        }
    }
    public string Atrybut5
    {
        get
        {
            return _hotelInfo.Atrybut5;
        }
    }
    public string WolnePokoje
    {
        get
        {
            return _hotelInfo.WolnePokoje;
        }
    }
    
    public string LoggedUser
    {
        get
        {
            return _login._loggedUser;
        }
    }
    public ICommand ChangeViewCommand { get; }
    public HotelInfoViewModel(NavigationService viewNavigationService, Login login, string clickedHotelButton, HotelsBrowser hotelsBrowser)
    {
        _hotelsBrowser = hotelsBrowser;
        switch (clickedHotelButton.Remove(0, 12))
        {
            case "1":
                _hotelInfo.ClickedHotelButton = hotelsBrowser.NazwaHotelu1;
                _hotelInfo.Atrybut2 = hotelsBrowser.Atrybut122;
                _hotelInfo.Atrybut3 = hotelsBrowser.Atrybut123;
                _hotelInfo.Atrybut4 = hotelsBrowser.Atrybut124;
                _hotelInfo.Atrybut5 = hotelsBrowser.Atrybut125;
                _hotelInfo.Zdjecie = hotelsBrowser.Zdjecie1;
                _hotelInfo.WolnePokoje = hotelsBrowser.WolnePokoje1;
                break;
            case "2":
                _hotelInfo.ClickedHotelButton = hotelsBrowser.NazwaHotelu2;
                _hotelInfo.Atrybut2 = hotelsBrowser.Atrybut222;
                _hotelInfo.Atrybut3 = hotelsBrowser.Atrybut223;
                _hotelInfo.Atrybut4 = hotelsBrowser.Atrybut224;
                _hotelInfo.Atrybut5 = hotelsBrowser.Atrybut225;
                _hotelInfo.Zdjecie = hotelsBrowser.Zdjecie2;
                _hotelInfo.WolnePokoje = hotelsBrowser.WolnePokoje2;
                break;
            case "3":
                _hotelInfo.ClickedHotelButton = hotelsBrowser.NazwaHotelu3;
                _hotelInfo.Atrybut2 = hotelsBrowser.Atrybut322;
                _hotelInfo.Atrybut3 = hotelsBrowser.Atrybut323;
                _hotelInfo.Atrybut4 = hotelsBrowser.Atrybut324;
                _hotelInfo.Atrybut5 = hotelsBrowser.Atrybut325;
                _hotelInfo.Zdjecie = hotelsBrowser.Zdjecie3;
                _hotelInfo.WolnePokoje = hotelsBrowser.WolnePokoje3;
                break;
        }

        _hotelInfo.WybranyHotel = Int32.Parse(clickedHotelButton.Remove(0, 12));
        _login = login;
        ChangeViewCommand = new ChangeViewCommand(viewNavigationService, login, _hotelsBrowser ,_hotelInfo);
    }

}