using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagementSystem.Entities;

public class RentalRequestEntityConfiguration : IEntityTypeConfiguration<RentalRequest>
{
    public void Configure(EntityTypeBuilder<RentalRequest> builder)
    {
        builder.HasKey(rr => rr.Id);

        builder.HasOne(rr => rr.User)
               .WithMany()
               .HasForeignKey(rr => rr.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rr => rr.Product)
               .WithMany()
               .HasForeignKey(rr => rr.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(rr => rr.RentalStartDate)
               .IsRequired();

        builder.Property(rr => rr.RentalEndDate)
               .IsRequired();

        builder.Property(rr => rr.RentalPeriod)
               .IsRequired()
               .HasConversion<int>();

        builder.Property(rr => rr.Status)
               .IsRequired()
               .HasConversion<int>();
    }
}
