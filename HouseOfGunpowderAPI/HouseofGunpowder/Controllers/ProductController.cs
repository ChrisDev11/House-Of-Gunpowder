using HouseofGunpowder.Models;
using HouseofGunpowder.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseofGunpowder.Controllers {

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : Controller {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts() {
            List<ProductModel> products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<ProductModel>> GetById(int guid) {
            ProductModel product = await _productRepository.GetProductById(guid);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> Register([FromBody] ProductModel productModel) {
            ProductModel product = await _productRepository.AddProduct(productModel);
            return Ok(product);
        }

        [HttpPut("{guid}")]
        public async Task<ActionResult<ProductModel>> Update([FromBody] ProductModel productModel, int guid) {
            productModel.Id = guid;
            ProductModel product = await _productRepository.UpdateProduct(productModel, guid);
            return Ok(product);
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult<ProductModel>> Delete(int guid) {
            bool deleted = await _productRepository.DeleteProduct(guid);
            return Ok(deleted);
        }
    }
}
