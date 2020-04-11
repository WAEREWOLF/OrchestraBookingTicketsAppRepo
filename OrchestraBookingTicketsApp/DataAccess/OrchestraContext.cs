using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.DataAccess
{
    public class OrchestraContext : DbContext
    {
        public OrchestraContext(DbContextOptions<OrchestraContext> options) : base(options)
        {
        }

        public DbSet<Orchestra> Orchestras { get; set; }
        public DbSet<LeadArtist> LeadArtists { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OrchestraHistory> OrchestraHistories { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<BuildingFacilities> BuildingFacilities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
