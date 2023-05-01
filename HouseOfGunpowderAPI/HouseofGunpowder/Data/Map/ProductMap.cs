using HouseofGunpowder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseofGunpowder.Data.Map {
    public class ProductMap : IEntityTypeConfiguration<ProductModel> {
        public void Configure(EntityTypeBuilder<ProductModel> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.SupplierId);
            builder.HasOne(x => x.Supplier);
        }
    }
}
