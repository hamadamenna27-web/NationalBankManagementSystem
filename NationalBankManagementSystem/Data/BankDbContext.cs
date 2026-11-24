using Microsoft.EntityFrameworkCore;
using NationalBankManagementSystem.Models;
#region Data


//namespace NationalBankManagementSystem.Data
//{
//    public class BankDbContext : DbContext
//    {
//        public BankDbContext(DbContextOptions<BankDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<Branch> Branches { get; set; }
//        public DbSet<Manager> Managers { get; set; }
//        public DbSet<Customer> Customers { get; set; }
//        public DbSet<Account> Accounts { get; set; }
//        public DbSet<Transaction> Transactions { get; set; }
//        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.ApplyConfigurationsFromAssembly(
//                typeof(BankDbContext).Assembly);

//            modelBuilder.Entity<Branch>().HasData(
//                new Branch
//                {
//                    Code = "BR001",
//                    Name = "Main Branch",
//                    Address = "Sohag",
//                    PhoneNumber = "01000000000"
//                }
//            );

//            modelBuilder.Entity<Manager>().HasData(
//                new Manager
//                {
//                    Id = 1,
//                    FullName = "Ahmed Mohamed",
//                    Email = "ahmed@bank.com",
//                    PhoneNumber = "01011111111",
//                    HireDate = new DateTime(2024, 1, 1),
//                    BranchCode = "BR001"
//                }
//            );

//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}
#endregion