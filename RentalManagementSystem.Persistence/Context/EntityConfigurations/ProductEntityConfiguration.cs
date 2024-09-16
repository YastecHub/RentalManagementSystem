using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagementSystem.Entities;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200); 

        builder.Property(p => p.Description)
            .HasMaxLength(1000); 

        builder.Property(p => p.RentalPrice)
            .HasColumnType("decimal(18,2)") 
            .IsRequired();

        builder.Property(p => p.StockQuantity)
            .IsRequired();

        builder.Property(p => p.Available)
            .IsRequired();
    }
}
