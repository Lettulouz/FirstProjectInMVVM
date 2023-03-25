using System.Collections.Generic;
using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;
using Projekt_v0._04.Stores;

namespace Projekt_v0._04.ViewModels;

public class MainBrowserViewModel : ViewModelBase
{
    private Browser _browser = new Browser();
    private Login _login;


    public List<string> Cities
    {
        get
        {
            return _browser.Cities;
        }
        set
        {
            _browser.Cities = value;
        }
    }

    public string SelectedCity
    {
        get
        {
            return _browser.SelectedCity;
        }
        set
        {
            _browser.SelectedCity = value;
        }
    }
    public string LoggedUser
    {
        get
        {
            return _login._loggedUser;
        }
    }
    public ICommand ChangeViewCommand { get;}

    public MainBrowserViewModel(NavigationService viewNavigationService, Login login)
    {
        _login = login;
        ChangeViewCommand = new ChangeViewCommand(viewNavigationService, _browser, login);
    }
}