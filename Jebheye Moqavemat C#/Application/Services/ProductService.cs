using Application.Dtos.ProductDtos;
using Domain.Entities;
using Domain.Interfaces.IProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService 
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public ProductEntity CreateProduct(CRUDProductDTO input)
        {
            return _repository.CreateProduct(input._Name, input._Dimensions);
        }
        public ProductEntity GetProductById(int productId)
        {
            return _repository.GetProductById(productId);
        }
        public ProductEntity UpdateProduct(ProductEntity input)
        {
            return _repository.UpdateProduct (input);  
        }
        public bool DeleteProduct(int productId)
        {
            return _repository.DeleteProduct(productId);
        }
        public List<ProductEntity> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }
        public int GetProductSerialCount(int productId, int warehouseId)
        {
            return _repository.GetProductSerialCount(productId, warehouseId);
        }
        public IEnumerable<dynamic> GetProductLocationDetails(int productId)
        {
            return _repository.GetProductLocationDetails(productId);
        }
    }
}
