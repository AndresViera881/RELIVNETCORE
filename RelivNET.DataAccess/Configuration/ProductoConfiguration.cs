using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelivNET.Entities;

namespace RelivNET.DataAccess.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Precio).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.HasOne(p => p.Categoria).WithMany().HasForeignKey(p => p.CategoriaId);
            builder.HasOne(p => p.Estado).WithMany().HasForeignKey(p => p.EstadoId);
            builder.ToTable("Producto");
        }
    }
}
