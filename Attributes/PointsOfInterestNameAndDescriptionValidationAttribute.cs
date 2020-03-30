using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CityInfoAPI.Models;

namespace CityInfoAPI.Attributes
{
    public class PointsOfInterestNameAndDescriptionValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance;

            if(obj is IPointOfInterestUpdateDto pointOfInterest){
                var name = pointOfInterest.Name;
                var desc = pointOfInterest.Description;

                if(string.Equals(name, desc, StringComparison.InvariantCultureIgnoreCase)){
                    return new ValidationResult("Name and Description have to different");
                }else{
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"Object needs to be of type {nameof(IPointOfInterestUpdateDto)} but was of type {obj?.GetType()}");
        }
    }
}