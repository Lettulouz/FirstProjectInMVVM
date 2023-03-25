using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.Models;
using Projekt_v0._04.Services;

namespace Projekt_v0._04.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private Login _login;
    public ICommand ChangeViewCommand { get; }
    
    public string LoginUsername
    {
        get
        {
            return _login._loginUsername;
        }
        set
        {
            _login._loginUsername = value;
            OnPropertyChanged(nameof(LoginUsername));
        }
    }
    public string LoginPassword
    {
        get
        {
            return _login._loginPassword;
        }
        set
        {
            _login._loginPassword = value;
            OnPropertyChanged(nameof(LoginPassword));
        }
    }
    
    public LoginViewModel(NavigationService viewNavigationService, Login login)
    {
        _login = login;
        ChangeViewCommand = new ChangeViewCommand(this, viewNavigationService, _login);
    }
    
}