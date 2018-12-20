using BlazorCrud.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace BlazorCrud.Server.DataAccess
{
  public class EmployeeContext : DbContext
  {
    static IConfiguration Configuration { get; set; }
    public virtual DbSet<Employee> tblEmployee { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        Configuration = builder.Build();

        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
      }
    }
  }
}
