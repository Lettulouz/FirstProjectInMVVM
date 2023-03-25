using Microsoft.EntityFrameworkCore;

namespace Projekt_v0._04.DbContexts;


public class ProjektDbContextFactory
{
    private string _connectionString = "stąd zostały usunięte dane do logowania do bazy danych";

    public ProjektDbContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ProjektDbContext CreateDbContext()
    {
        DbContextOptions options = new DbContextOptionsBuilder().UseMySql
            (_connectionString,new MySqlServerVersion("8.0.29")).Options;
        return new ProjektDbContext(options);
    }
    
}
