using HouseofGunpowder.Data.Map;
using HouseofGunpowder.Models;
using Microsoft.EntityFrameworkCore;
namespace HouseofGunpowder.Data {
    public class GunpowderDBContext : DbContext {
        public GunpowderDBContext(DbContextOptions<GunpowderDBContext> options)
            : base(options) {
        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new SupplierMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
