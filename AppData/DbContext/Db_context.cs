using System.Reflection;
using AppData.Model;
using Microsoft.EntityFrameworkCore;

namespace AppData.DbContext;

public class Db_context : Microsoft.EntityFrameworkCore.DbContext
{
    public Db_context()
    {
    }

    public Db_context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<NhanVien> NhanViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=BuiDoanhThai_Ph22339;User Id=SA;Password=Dthai16gg!;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}