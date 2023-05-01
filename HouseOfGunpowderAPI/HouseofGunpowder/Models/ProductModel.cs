namespace HouseofGunpowder.Models {
    public class ProductModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? SupplierId { get; set; }
        public virtual SupplierModel? Supplier { get; set; }
    }
}
