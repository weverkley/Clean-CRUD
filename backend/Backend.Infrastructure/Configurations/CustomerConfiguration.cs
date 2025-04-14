using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(c => c.Id);

            builder.HasIndex(i => i.CPFCNPJ)
                .IsUnique();

            builder.Property(x => x.CPFCNPJ)
                .HasColumnName("cpfCnpj")
                .IsRequired();

            builder.Property(x => x.NomeRazao)
                .HasColumnName("nomeRazao")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("dataNascimento")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("isActive")
                .HasDefaultValue(false)
                .IsRequired();

        builder.Property(c => c.CreatedAt)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.UpdatedAt)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("updatedAt")
                .ValueGeneratedOnAddOrUpdate();

            builder.HasMany(h => h.Addresses)
                .WithOne(w => w.Customer)
                .HasForeignKey(f => f.CustomerId);
        }
    }
}
