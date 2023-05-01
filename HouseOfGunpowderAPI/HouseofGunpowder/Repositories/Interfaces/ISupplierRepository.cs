using HouseofGunpowder.Models;

namespace HouseofGunpowder.Repositories.Interfaces {
    public interface ISupplierRepository {
        Task<List<SupplierModel>> GetAllSuppliers();
        Task<SupplierModel> GetSupplierById(long cnpj);
        Task<SupplierModel> AddSupplier(SupplierModel supplier);
        Task<SupplierModel> UpdateSuppliers(SupplierModel supplier, long cnpj);
        Task<bool> DeleteSupplier(long cnpj);
    }
}
