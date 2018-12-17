using BlazorCrud.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.DataAccess
{
  public class EmployeeContext : DbContext
  {
    public virtual DbSet<Employee> tblEmployee { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=MaG_db;User ID=sa;Password=gunasekar;Integrated Security=true");
      }
    }
  }
}
