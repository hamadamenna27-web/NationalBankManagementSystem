
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBankManagementSystem.Models;

namespace NationalBankManagementSystem.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Code)
                   .HasMaxLength(10);

            builder.Property(b => b.Name)
                   .IsRequired();

            builder.Property(b => b.Address)
                   .IsRequired();

            builder.Property(b => b.PhoneNumber)
                   .IsRequired();

            builder.HasOne(b => b.Manager)
                   .WithOne(m => m.Branch)
                   .HasForeignKey<Manager>(m => m.BranchCode);
        }
    }
}
