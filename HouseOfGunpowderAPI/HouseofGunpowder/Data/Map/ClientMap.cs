using HouseofGunpowder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseofGunpowder.Data.Map {
    public class ClientMap : IEntityTypeConfiguration<ClientModel> {
        public void Configure(EntityTypeBuilder<ClientModel> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        }
    }
}
