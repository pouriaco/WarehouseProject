using Application.Dtos.ProductDtos;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.IProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jebheye_Moqavemat_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;

        public ProductController(IProductRepository productService) 
        { 
            _productService =  new ProductService(productService);
        }
        [HttpPost("CreateProduct")]
        public ProductEntity CreateProduct(CRUDProductDTO DTO) => _productService.CreateProduct(DTO);
       
        [HttpGet("GetByProduct")]
        public ProductEntity GetProductById(int id) => _productService.GetProductById(id);

        [HttpPut("UpdateProduct")]
        public ProductEntity UpdateProduct(ProductEntity input) => _productService.UpdateProduct(input);

        [HttpDelete("DeleteProduct")]
        public bool DeleteProduct(int id) => _productService.DeleteProduct(id);

        [HttpGet("GetAllProduct")]
        public List<ProductEntity> GetAllProducts() => _productService.GetAllProducts();

        [HttpGet("GetProductSerialCountInWarehous")]
        public int GetProductSerialCount(int productId, int warehouseId) => _productService.GetProductSerialCount(productId, warehouseId);

    }
}
