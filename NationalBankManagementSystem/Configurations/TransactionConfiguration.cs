
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBankManagementSystem.Models;
#region Configurations

//namespace NationalBankManagementSystem.Configurations
//{
//    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
//    {
//        public void Configure(EntityTypeBuilder<Transaction> builder)
//        {
//            builder.HasKey(t => t.TransactionNumber);

//            builder.Property(t => t.Amount)
//                   .HasColumnType("decimal(18,2)");

//            builder.Property(t => t.TransactionDate)
//                   .IsRequired();

//            builder.Property(t => t.TransactionType)
//                   .IsRequired();
//        }
//    }
//}
#endregion
