using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Data
{
    public class Testare_TravelingAppContext : DbContext
    {
        public Testare_TravelingAppContext (DbContextOptions<Testare_TravelingAppContext> options)
            : base(options)
        {
        }

        public DbSet<Testare_TravelingApp.Models.User> User { get; set; } = default!;
        public DbSet<Testare_TravelingApp.Models.TouristAttraction> TouristAttraction { get; set; } = default!;
        public DbSet<Testare_TravelingApp.Models.Review> Review { get; set; } = default!;
        public DbSet<Testare_TravelingApp.Models.Restaurant> Restaurant { get; set; } = default!;
        public DbSet<Testare_TravelingApp.Models.NatureTrail> NatureTrail { get; set; } = default!;
        public DbSet<Testare_TravelingApp.Models.Agenda> Agenda { get; set; } = default!;
        public DbSet<Testare_TravelingApp.Models.Activity> Activity { get; set; } = default!;
    }
}
