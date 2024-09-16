using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagementSystem.Entities;

public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.ReportName)
               .IsRequired()
               .HasMaxLength(200);  

        builder.Property(r => r.GeneratedDate)
               .IsRequired();

        builder.HasOne(r => r.GeneratedByUser)
               .WithMany()  
               .HasForeignKey(r => r.GeneratedByUserId)
               .OnDelete(DeleteBehavior.Restrict);  

        builder.Property(r => r.StartDate)
               .IsRequired(false);  

        builder.Property(r => r.EndDate)
               .IsRequired(false);

        builder.Property(r => r.TotalRentalRequests)
               .IsRequired();

        builder.Property(r => r.TotalRevenue)
               .HasColumnType("decimal(18,2)")  
               .IsRequired();
    }
}
