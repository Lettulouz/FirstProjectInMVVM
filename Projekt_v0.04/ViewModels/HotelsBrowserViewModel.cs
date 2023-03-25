using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;

namespace Projekt_v0._04.ViewModels;

public class HotelsBrowserViewModel : ViewModelBase
{
    private Browser _browser;
    private HotelsBrowser _hotelsBrowser = new HotelsBrowser();
    private Login _login;

    public string Zdjecie1
    {
        get
        {
            return _hotelsBrowser.Zdjecie1;
        }
    }
    
    public string Zdjecie2
    {
        get
        {
            return _hotelsBrowser.Zdjecie2;
        }
    }
    public string Zdjecie3
    {
        get
        {
            return _hotelsBrowser.Zdjecie3;
        }
    }
    public bool IsEnabled1
    {
        get
        {
            return _hotelsBrowser.IsEnabled1;
        }
    }
    public bool IsEnabled2
    {
        get
        {
            return _hotelsBrowser.IsEnabled2;
        }
    }
    public bool IsEnabled3
    {
        get
        {
            return _hotelsBrowser.IsEnabled3;
        }
    }
    public string NazwaHotelu1
    {
        get
        {
            return _hotelsBrowser.NazwaHotelu1;
        }
    }
    public string WolnePokoje1
    {
        get
        {
            return _hotelsBrowser.WolnePokoje1;
        }
    }
    public string NazwaHotelu2
    {
        get
        {
            return _hotelsBrowser.NazwaHotelu2;
        }
    }
    public string WolnePokoje2
    {
        get
        {
            return _hotelsBrowser.WolnePokoje2;
        }
    }
    public string NazwaHotelu3
    {
        get
        {
            return _hotelsBrowser.NazwaHotelu3;
        }
    }
    public string WolnePokoje3
    {
        get
        {
            return _hotelsBrowser.WolnePokoje3;
        }
    }
    public string Atrybut122
    {
        get
        {
            return _hotelsBrowser.Atrybut122;
        }
    }
    public string Atrybut123
    {
        get
        {
            return _hotelsBrowser.Atrybut123;
        }
    }
    public string Atrybut124
    {
        get
        {
            return _hotelsBrowser.Atrybut124;
        }
    }
    public string Atrybut125
    {
        get
        {
            return _hotelsBrowser.Atrybut125;
        }
    }
    public string Atrybut222
    {
        get
        {
            return _hotelsBrowser.Atrybut222;
        }
    }
    public string Atrybut223
    {
        get
        {
            return _hotelsBrowser.Atrybut223;
        }
    }
    public string Atrybut224
    {
        get
        {
            return _hotelsBrowser.Atrybut224;
        }
    }
    public string Atrybut225
    {
        get
        {
            return _hotelsBrowser.Atrybut225;
        }
    }
    public string Atrybut322
    {
        get
        {
            return _hotelsBrowser.Atrybut322;
        }
    }
    public string Atrybut323
    {
        get
        {
            return _hotelsBrowser.Atrybut323;
        }
    }
    public string Atrybut324
    {
        get
        {
            return _hotelsBrowser.Atrybut324;
        }
    }
    public string Atrybut325
    {
        get
        {
            return _hotelsBrowser.Atrybut325;
        }
    }

    public double Wyszukanie1Przejrzystosc
    {
        get
        {
            return _hotelsBrowser.Wyszukanie1Przejrzystosc;
        }
    }
    public double Wyszukanie2Przejrzystosc
    {
        get
        {
            return _hotelsBrowser.Wyszukanie2Przejrzystosc;
        }
    }
    public double Wyszukanie3Przejrzystosc
    {
        get
        {
            return _hotelsBrowser.Wyszukanie3Przejrzystosc;
        }
    }
    public string SelectedCity
    {
        get
        {
            return _hotelsBrowser.SelectedCity;
        }
        set
        {
            _hotelsBrowser.SelectedCity = value;
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

    public HotelsBrowserViewModel(NavigationService viewNavigationService, Browser browser, Login login)
    {
        _browser = browser;
        _login = login;
        SelectedCity = _browser.SelectedCity;
        ChangeViewCommand = new ChangeViewCommand(viewNavigationService, login, _hotelsBrowser);
        _hotelsBrowser.LoadHotelsProperties();
    }
    
}