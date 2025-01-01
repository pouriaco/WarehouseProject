using Application.Dtos.WarehouseDtos;
using Domain.Entities;
using Domain.Interfaces.IWarehouses;
using System.Collections.Generic;

namespace Application.Services
{
    public class CityService
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public CityEntity CreateCity(CRUDCityDTO cityDto)
        {
            return _repository.CreateCity(cityDto.Name);
        }

        public CityEntity GetCityById(int cityId)
        {
            try
            {
                return _repository.GetCityById(cityId);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
        }

        public CityEntity UpdateCity(int id, CRUDCityDTO cityDto)
        {
            try
            {
                return _repository.UpdateCity(id, cityDto.Name);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
        }

        public bool DeleteCity(int cityId)
        {
            try
            {
                return _repository.DeleteCity(cityId);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
        }
    }
}
