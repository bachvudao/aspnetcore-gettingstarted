using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(x => x.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(x => x.PointsOfInterest)
                    .Where(x => x.Id == cityId).FirstOrDefault();
            }

            return _context.Cities.Where(x => x.Id == cityId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest.Where(p => p.CityId == cityId).ToList();
        }

        public PointOfInterest GetPointsOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest.Where(p => p.Id == pointOfInterestId && p.CityId == cityId).FirstOrDefault();
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest poi)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(poi);
        }

        public void UpdatePointOfInterestForCity(int cityId, PointOfInterest poi)
        {

        }

        public void DeletePointOfInterest(PointOfInterest poi)
        {
            _context.PointsOfInterest.Remove(poi);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

    }
}
