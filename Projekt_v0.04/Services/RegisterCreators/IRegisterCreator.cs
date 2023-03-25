using System.Threading.Tasks;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.RegisterCreators;

public interface IRegisterCreator
{
    Task CreateAccount(Login login);
    Task LoginToAccount(Login login);
}