using HouseofGunpowder.Data;
using HouseofGunpowder.Models;
using HouseofGunpowder.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseofGunpowder.Repositories {
    public class SupplierRepository : ISupplierRepository {

        private readonly GunpowderDBContext _dbContext;
        public SupplierRepository(GunpowderDBContext gunpowderDBContext) {
            _dbContext = gunpowderDBContext;
        }

        public async Task<SupplierModel> GetSupplierById(long cnpj) {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.CNPJ == cnpj);
        }

        public async Task<List<SupplierModel>> GetAllSuppliers() {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task<SupplierModel> AddSupplier(SupplierModel supplier) {
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
            return supplier;
        }

        public async Task<SupplierModel> UpdateSuppliers(SupplierModel supplier, long cnpj) {
            SupplierModel supplierById = await GetSupplierById(cnpj);

            if (supplierById == null) {
                throw new Exception($"Fornecedor com CNPJ: {cnpj} não foi encontrado.");
            }

            supplierById.Name = supplier.Name;
            supplierById.CNPJ = supplier.CNPJ;
            supplierById.Agent = supplier.Agent;
            supplierById.Phone = supplier.Phone;

            _dbContext.Suppliers.Update(supplierById);
            await _dbContext.SaveChangesAsync();

            return supplierById;
        }

        public async Task<bool> DeleteSupplier(long cnpj) {

            SupplierModel supplierById = await GetSupplierById(cnpj);

            if (supplierById == null) {
                throw new Exception($"Fornecedor com Id: {cnpj} não foi encontrado.");
            }

            _dbContext.Suppliers.Remove(supplierById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
