
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBankManagementSystem.Models;

namespace NationalBankManagementSystem.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.FullName)
                   .IsRequired();

            builder.Property(m => m.Email)
                   .IsRequired();

            builder.Property(m => m.PhoneNumber)
                   .IsRequired();

            builder.Property(m => m.HireDate)
                   .IsRequired();
        }
    }
}
