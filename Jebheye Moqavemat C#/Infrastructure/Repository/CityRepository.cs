using Domain.Entities;
using Domain.Interfaces.IWarehouses;
using Infrastructure.dbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly dbContextDatabase _context;

        public CityRepository(dbContextDatabase context)
        {
            _context = context;
        }

        public CityEntity CreateCity(string name)
        {
            var city = new CityEntity { Name = name };
            _context.Citys.Add(city);
            _context.SaveChanges();
            return city;
        }

        public CityEntity GetCityById(int cityId)
        {
            var city = _context.Citys.Find(cityId);
            if (city == null)
            {
                throw new KeyNotFoundException("City not found");
            }
            return city;
        }

        public CityEntity UpdateCity(int id, string name)
        {
            var city = _context.Citys.Find(id);
            if (city == null)
            {
                throw new KeyNotFoundException("City not found");
            }
            city.Name = name;
            _context.SaveChanges();
            return city;
        }

        public bool DeleteCity(int cityId)
        {
            var city = _context.Citys.Find(cityId);
            if (city == null)
            {
                throw new KeyNotFoundException("City not found");
            }
            _context.Citys.Remove(city);
            _context.SaveChanges();
            return true;
        }
    }
}
