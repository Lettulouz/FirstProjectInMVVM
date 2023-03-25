using Microsoft.EntityFrameworkCore;
using Projekt_v0._04.DTOs;

namespace Projekt_v0._04.DbContexts;


public class ProjektDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ProjektDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<LoginDTO> Login { get; set; }
    public DbSet<ReservationDTO> Reservations { get; set; }
}
