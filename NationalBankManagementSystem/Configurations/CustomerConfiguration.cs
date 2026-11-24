
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBankManagementSystem.Models;

namespace NationalBankManagementSystem.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                   .IsRequired();

            builder.Property(c => c.NationalId)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .IsRequired();

            builder.Property(c => c.PhoneNumber)
                   .IsRequired();

            builder.Property(c => c.Address)
                   .IsRequired();

            builder.Property(c => c.CustomerType)
                   .IsRequired();
        }
    }
}
