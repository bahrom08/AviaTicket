using Domain.Entities.Airlains;
using Domain.Entities.Airports;
using Domain.Entities.Currencies;
using Domain.Entities.Orders;
using Domain.Entities.Regions;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Airlain> Airlains { get; set; }
    DbSet<Airport> Airports { get; set; }
    DbSet<Currency> Currencies { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderRoute> OrderRoutes { get; set; }
    DbSet<OrderFlight> OrderFlights { get; set; }
    DbSet<OrderPassenger> OrderPassengers { get; set; }
    DbSet<OrderStatus> OrderStatuses { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<User> Users { get; set; } 

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DatabaseFacade Database { get; }
}
