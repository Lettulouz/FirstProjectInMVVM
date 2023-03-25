using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;

namespace Projekt_v0._04.ViewModels;

public class AboutUsViewModel : ViewModelBase
{
    private AboutUs aboutUs = new AboutUs();
    private Login _login;
    public string AboutUsMessage
    {
        get
        {
            return aboutUs.AboutUsMessage;
        }
    }

    public double FontSizeDefine
    {
        get
        {
            return aboutUs.FontSizeDefine;
        }
    }

    public string ImageLeftSource
    {
        get
        {
            return aboutUs.ImageLeftSource;
        }
    }

    public string ImageCenterSource
    {
        get
        {
            return aboutUs.ImageCenterSource;
        }
    }
    public string ImageRightSource
    {
        get
        {
            return aboutUs.ImageRightSource;
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

    public AboutUsViewModel(NavigationService viewNavigationService, Login login)
    {
        _login = login;
        ChangeViewCommand = new ChangeViewCommand(viewNavigationService, _login);
    }
}