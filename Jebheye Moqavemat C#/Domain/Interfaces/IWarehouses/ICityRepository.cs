using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IWarehouses
{
    public interface ICityRepository
    {
     /* C */   public CityEntity CreateCity(string name);
     /* R */   public CityEntity GetCityById(int cityId);
     /* U */   public CityEntity UpdateCity(int id, string name);
     /* D */   public bool DeleteCity(int cityId);

    }
}
