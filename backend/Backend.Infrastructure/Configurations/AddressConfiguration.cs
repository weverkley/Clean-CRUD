using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("endereco");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.CustomerId)
                .HasColumnName("clienteId")
                .IsRequired();

            builder.Property(x => x.Logradouro)
                .HasColumnName("logradouro")
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasColumnName("numero")
                .IsRequired();

            builder.Property(x => x.Complemento)
               .HasColumnName("complemento")
               .IsRequired();

            builder.Property(x => x.Bairro)
               .HasColumnName("bairro")
               .IsRequired();

            builder.Property(x => x.Cidade)
               .HasColumnName("cidade")
               .IsRequired();

            builder.Property(x => x.Estado)
               .HasColumnName("estado")
               .IsRequired();

            builder.Property(x => x.CEP)
               .HasColumnName("cep")
               .IsRequired();

            builder.Property(c => c.CreatedAt)
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();

            builder.Property(c => c.UpdatedAt)
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
