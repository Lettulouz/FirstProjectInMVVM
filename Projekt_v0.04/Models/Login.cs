using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Projekt_v0._04.Commands;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.Exceptions;
using Projekt_v0._04.Services.RegisterConfictValidatiors;
using Projekt_v0._04.Services.RegisterCreators;
using Projekt_v0._04.Services.LoginProvider;

namespace Projekt_v0._04.Models;

public class Login
{
    public string _loginUsername = "Gość";
    public string _loginPassword = "";
    public string _loggedUser = "Gość";
    private const string CONNECTION_STRING = 
        "stąd zostały usunięte dane do logowania do bazy danych";

    private ILoginProvider loginProvider;
    private IRegisterCreator registerCreator;
    private IRegisterConflictValidator registerConflictValidator;
    public Login()
    {
        ProjektDbContextFactory projektDbContextFactory = new ProjektDbContextFactory(CONNECTION_STRING);
        loginProvider = new DatabaseLoginProvider(projektDbContextFactory);
        registerCreator = new DatabaseRegisterCreator(projektDbContextFactory);
        registerConflictValidator = new DatabaseRegisterConflictValidator(projektDbContextFactory);
    }
    public Login(string loginUsername, string loginPassword)
    {
        _loginUsername = loginUsername;
        _loginPassword = loginPassword;
        ProjektDbContextFactory projektDbContextFactory = new ProjektDbContextFactory(CONNECTION_STRING);
        loginProvider = new DatabaseLoginProvider(projektDbContextFactory);
        registerCreator = new DatabaseRegisterCreator(projektDbContextFactory);
        registerConflictValidator = new DatabaseRegisterConflictValidator(projektDbContextFactory);
    }

    public async Task CreateAccount(Login login)
    {
        Login conflictingLogin = await registerConflictValidator.GetConflictingRegister(login);
        if (conflictingLogin != null)
        {
            throw new RegisterConflictException(conflictingLogin, login);
        }
       await registerCreator.CreateAccount(login);
       login._loggedUser = login._loginUsername;
    }

    public async Task CheckIfAccountExists(Login login)
    {
        await loginProvider.CheckIfAccountExists(login);
    }

    public bool AccountExists()
    {
        return loginProvider.AccountExists();
    }
}