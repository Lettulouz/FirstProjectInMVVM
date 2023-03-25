using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using Microsoft.EntityFrameworkCore;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.DTOs;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.LoginProvider;

public class DatabaseLoginProvider : ILoginProvider
{
    private readonly ProjektDbContextFactory _dbContextFactory;
    private bool check = false;
    public DatabaseLoginProvider(ProjektDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Login> CheckIfAccountExists(Login login)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            if (!context.Login.Any(o => o.loginUsername == login._loginUsername))
            {
                MessageBox.Show("Takie konto nie istnieje.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                check = false;
                return login;
            }
            else
            {
                check = true;
                var test = await context.Login.FirstOrDefaultAsync(r =>
                    r.loginUsername == login._loginUsername && r.loginPassword == login._loginPassword);
                if (test != null)
                {
                    MessageBox.Show("Zalogowano na konto: "  + login._loginUsername, "Zalogowano", MessageBoxButton.OK, MessageBoxImage.Information);
                    login._loggedUser = login._loginUsername;
                }
                    return login;
            }

        }
    }

    public bool AccountExists()
    {
        if (!check)
            return false;
        else
            return true;
    }
}