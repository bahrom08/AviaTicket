using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities.Airlains;
using Domain.Entities.Airports;
using Domain.Entities.Currencies;
using Domain.Entities.Orders;
using Domain.Entities.Regions;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection;

namespace Infrastructure.DataAccess.Contexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Airlain> Airlains { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderRoute> OrderRoutes { get; set; }
    public DbSet<OrderFlight> OrderFlights { get; set; }
    public DbSet<OrderPassenger> OrderPassengers { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}