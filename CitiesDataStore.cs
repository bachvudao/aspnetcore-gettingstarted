using System;
using System.Collections.Generic;
using System.Linq;
using CityInfoAPI.Models;

namespace CityInfoAPI
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public IList<CityDto> Cities { get; private set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto() {
                            Id = 1,
                            Name = "Central Park",
                            Description = "Special Park"
                        },
                        new PointOfInterestDto() {
                            Id = 2,
                            Name = "Point 2", 
                            Description = "About Point 2"
                        }
                    }
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "Another city",
                },
                new CityDto
                {
                    Id = 3,
                    Name = "San Francisco",
                    Description = "Another another city",
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto() {
                            Id = 4,
                            Name = "Point 4",
                            Description = "About Pt 4"
                        },
                        new PointOfInterestDto() {
                            Id = 5,
                            Name = "Point 5", 
                            Description = "About Point 5"
                        }
                    }
                }
            };
        }
    }
}