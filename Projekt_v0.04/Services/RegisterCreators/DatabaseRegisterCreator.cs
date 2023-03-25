using System.Threading.Tasks;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.DTOs;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.RegisterCreators;

public class DatabaseRegisterCreator : IRegisterCreator
{
    private readonly ProjektDbContextFactory _dbContextFactory;

    public DatabaseRegisterCreator(ProjektDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public async Task CreateAccount(Login login)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            LoginDTO loginDto = ToLoginDTO(login);

            context.Login.Add(loginDto);
            await context.SaveChangesAsync();
        }
    }
    public async Task LoginToAccount(Login login)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            LoginDTO loginDto = ToLoginDTO(login);

            context.Login.Add(loginDto);
            await context.SaveChangesAsync();
        }
    }

    private LoginDTO ToLoginDTO(Login login)
    {
        return new LoginDTO()
        {
            loginUsername = login._loginUsername,
            loginPassword = login._loginPassword
        };
    }
    
}