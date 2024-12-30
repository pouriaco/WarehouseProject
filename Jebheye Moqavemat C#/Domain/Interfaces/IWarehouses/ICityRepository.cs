using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IWarehouses
{
    internal interface ICityRepository
    {
     /* C */   public CityEntity CreateCity(string name);
     /* R */   public int GetCityById(int cityId);
     /* U */   public CityEntity UpdateCity(string name);
     /* D */   public bool DeleteCity(int cityId);
       
    }
}
