using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt_v0._04.DbContexts;
using Projekt_v0._04.DTOs;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.RegisterConfictValidatiors;

public class DatabaseRegisterConflictValidator : IRegisterConflictValidator
{
    private readonly ProjektDbContextFactory _dbContextFactory;
    public DatabaseRegisterConflictValidator(ProjektDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    
    public async Task<Login> GetConflictingRegister(Login login)
    {
        using (ProjektDbContext context = _dbContextFactory.CreateDbContext())
        {
            LoginDTO reservationDto = await context.Login
                .Where(r => r.loginUsername == login._loginUsername)
                .FirstOrDefaultAsync();
            if (reservationDto == null)
            {
                return null;
            }
            return ToReservation(reservationDto);
        }
    }

    private static Login ToReservation(LoginDTO dto)
    {
        return new Login(dto.loginUsername, dto.loginPassword);
    }
}