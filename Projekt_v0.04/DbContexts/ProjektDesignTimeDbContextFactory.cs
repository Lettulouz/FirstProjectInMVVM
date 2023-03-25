using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Projekt_v0._04.DbContexts;



public class ProjektDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjektDbContext>
{
    public ProjektDbContext CreateDbContext(string[] args)
    {
        
        DbContextOptions options = new DbContextOptionsBuilder().UseMySql
            ("stąd zostały usunięte dane do logowania do bazy danych",new MySqlServerVersion("8.0.29")).Options;
        return new ProjektDbContext(options);
        
    }
}
