using HouseofGunpowder.Models;

namespace HouseofGunpowder.Repositories.Interfaces {
    public interface IProductRepository {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int guid);
        Task<ProductModel> AddProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product, int guid);
        Task<bool> DeleteProduct(int guid);
    }
}
