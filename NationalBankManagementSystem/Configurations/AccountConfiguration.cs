
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBankManagementSystem.Models;
#region Configurations


//namespace NationalBankManagementSystem.Configurations
//{
//    public class AccountConfiguration : IEntityTypeConfiguration<Account>
//    {
//        public void Configure(EntityTypeBuilder<Account> builder)
//        {
//            builder.HasKey(a => a.AccountNumber);

//            builder.Property(a => a.AccountNumber)
//                   .HasMaxLength(20);

//            builder.Property(a => a.CurrentBalance)
//                   .HasColumnType("decimal(18,2)");

//            builder.Property(a => a.AccountType)
//                   .IsRequired();

//            builder.Property(a => a.OpeningDate)
//                   .IsRequired();

//            builder.HasOne(a => a.Branch)
//                   .WithMany()
//                   .HasForeignKey(a => a.BranchCode);

//            builder.HasMany(a => a.Transactions)
//                   .WithOne(t => t.Account)
//                   .HasForeignKey(t => t.AccountNumber);
//        }
//    }
//}
#endregion