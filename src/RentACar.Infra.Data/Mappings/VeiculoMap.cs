using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities;

namespace RentACar.Infra.Data.Mappings
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Placa)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(c => c.Ano)
                .IsRequired()
                .HasColumnType("varchar(4)")                
                .HasMaxLength(4);

            builder.Property(c => c.Combustivel)
                .IsRequired();

            builder.Property(c => c.Categoria)
                .IsRequired();

            builder.Property(c => c.ValorHora)
                .IsRequired();

            builder.Property(c => c.LimitePortaMalas)
                .IsRequired();

            builder.HasOne(x => x.Marca)
                   .WithMany(x => x.Veiculos);

            builder.HasOne(x => x.Modelo)
                   .WithMany(x => x.Veiculos);
        }
    }
}
