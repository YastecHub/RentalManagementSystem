using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagementSystem.Entities;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.HasKey(u => u.Id);  

        
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100); 

        
        builder.Property(u => u.AlternativePhoneNumber)
            .HasMaxLength(15); 

        
        builder.Property(u => u.Address)
            .HasMaxLength(500); 

        
        builder.Property(u => u.CustomerPhoto)
            .HasMaxLength(255); 

        builder.HasIndex(u => u.Email).IsUnique();  
    }
}
