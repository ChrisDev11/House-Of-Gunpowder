using HouseofGunpowder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseofGunpowder.Data.Map {
    public class SupplierMap : IEntityTypeConfiguration<SupplierModel> {
        public void Configure(EntityTypeBuilder<SupplierModel> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Agent).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(25);
        }
    }
}
