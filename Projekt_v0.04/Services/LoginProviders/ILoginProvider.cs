using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.LoginProvider;

public interface ILoginProvider
{
    Task<Login> CheckIfAccountExists(Login login);
    bool AccountExists();
}