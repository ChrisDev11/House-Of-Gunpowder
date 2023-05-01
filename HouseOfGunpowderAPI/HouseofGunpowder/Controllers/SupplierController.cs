using HouseofGunpowder.Models;
using HouseofGunpowder.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseofGunpowder.Controllers {

    [Route("api/[controller]")]
    [ApiController]

    public class SupplierController : Controller {

        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository) {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierModel>>> GetAllSuppliers() {
            List<SupplierModel> supplier = await _supplierRepository.GetAllSuppliers();
            return Ok(supplier);
        }

        [HttpGet("{cnpj}")]
        public async Task<ActionResult<SupplierModel>> GetById(long cnpj) {
            SupplierModel supplier = await _supplierRepository.GetSupplierById(cnpj);
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierModel>> Register([FromBody] SupplierModel supplierModel) {
            SupplierModel supplier = await _supplierRepository.AddSupplier(supplierModel);
            return Ok(supplier);
        }

        [HttpPut("{cnpj}")]
        public async Task<ActionResult<SupplierModel>> Update([FromBody] SupplierModel supplierModel, long cnpj) {
            supplierModel.CNPJ = cnpj;
            SupplierModel supplier = await _supplierRepository.UpdateSuppliers(supplierModel, cnpj);
            return Ok(supplier);
        }

        [HttpDelete("{cnpj}")]
        public async Task<ActionResult<SupplierModel>> Delete(long cnpj) {
            bool deleted = await _supplierRepository.DeleteSupplier(cnpj);
            return Ok(deleted);
        }
    }
}
