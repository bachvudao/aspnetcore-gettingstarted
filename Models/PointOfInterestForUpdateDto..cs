using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CityInfoAPI.Attributes;

namespace CityInfoAPI.Models
{
    public class PointOfInterestForUpdateDto : IPointOfInterestUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        [PointsOfInterestNameAndDescriptionValidation]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage="Description cannot be longer than 200 characters")]
        public string Description { get; set; }
    }
}