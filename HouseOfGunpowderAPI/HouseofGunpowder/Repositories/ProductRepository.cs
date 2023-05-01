using HouseofGunpowder.Data;
using HouseofGunpowder.Models;
using HouseofGunpowder.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseofGunpowder.Repositories {
    public class ProductRepository : IProductRepository {

        private readonly GunpowderDBContext _dbContext;
        public ProductRepository(GunpowderDBContext gunpowderDBContext) {
            _dbContext = gunpowderDBContext;
        }

        public async Task<ProductModel> GetProductById(int guid) {
            return await _dbContext.Products
                .Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == guid);
        }

        public async Task<List<ProductModel>> GetAllProducts() {
            return await _dbContext.Products
                .Include(x => x.Supplier)
                .ToListAsync();
        }

        public async Task<ProductModel> AddProduct(ProductModel product) {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product, int guid) {
            ProductModel productById = await GetProductById(guid);

            if (productById == null) {
                throw new Exception($"Produto com Id: {guid} não foi encontrado.");
            }

            productById.Name = product.Name;
            productById.Description = product.Description;
            productById.Price = product.Price;
            productById.SupplierId = product.SupplierId;

            _dbContext.Products.Update(productById);

            await _dbContext.SaveChangesAsync();

            return productById;
        }

        public async Task<bool> DeleteProduct(int guid) {

            ProductModel productById = await GetProductById(guid);

            if (productById == null) {
                throw new Exception($"Produto com Id: {guid} não foi encontrado.");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
