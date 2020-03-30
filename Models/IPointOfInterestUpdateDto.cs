using System;
using System.Collections.Generic;

namespace CityInfoAPI.Models
{
    public interface IPointOfInterestUpdateDto
    {
        public string Name { get; }

        public string Description { get; }
    }
}