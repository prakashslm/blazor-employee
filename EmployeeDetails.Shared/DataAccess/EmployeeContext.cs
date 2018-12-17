using EmployeeDetails.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Shared.DataAccess
{
  public class EmployeeContext : DbContext
  {
    public virtual DbSet<Employee> Employee { get; set; }
    public virtual DbSet<Cities> Cities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Sample;User ID=sa;Password=gunasekar;Integrated Security=true");
      }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Cities>(entity =>
      {
        entity.HasKey(e => e.CityId);
        entity.Property(e => e.CityId).HasColumnName("CityID");
        entity.Property(e => e.CityName).HasMaxLength(20).IsUnicode(false);
      });
      modelBuilder.Entity<Employee>(entity => 
      {
        entity.Property(e => e.Name).IsRequired().HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.Department).IsRequired().HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.Gender).IsRequired().HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.City).IsRequired().HasMaxLength(20).IsUnicode(false);
      });
    }
  }
}
