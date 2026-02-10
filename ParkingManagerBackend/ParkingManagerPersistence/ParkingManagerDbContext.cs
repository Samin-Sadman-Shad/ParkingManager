using Microsoft.EntityFrameworkCore;
using ParkingManagerApplication.Common.Contracts.Persistence;
using ParkingManagerDomain.Domains;

namespace ParkingManagerPersistence
{
    public class ParkingManagerDbContext:DbContext
    {
        public ParkingManagerDbContext(DbContextOptions<ParkingManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<GarageLocation> GarageLocations { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
