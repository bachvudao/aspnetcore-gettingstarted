using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = 1,
                Name = "New York",
                Description = "Big Apple"
            },
            new City()
            {
                Id = 2,
                Name = "Paris",
                Description = "City of Light"
            });

            modelBuilder.Entity<PointOfInterest>().HasData(new PointOfInterest()
            {
                Id = 1,
                Name = "Central Park",
                Description = "The big park",
                CityId = 1
            },
           new PointOfInterest()
           {
               Id = 2,
               Name = "Prospect Park",
               Description = "The second big park",
               CityId = 1
           }, new PointOfInterest()
           {
               Id = 3,
               Name = "Eiffel Tower",
               Description = "The really tall tower",
               CityId = 2
           });

            base.OnModelCreating(modelBuilder);
        }

    }
}
