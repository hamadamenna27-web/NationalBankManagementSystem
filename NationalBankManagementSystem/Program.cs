
using Microsoft.EntityFrameworkCore;
using NationalBankManagementSystem.Data;
using NationalBankManagementSystem.Models;
#region Program

//namespace NationalBankManagementSystem
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            var options = new DbContextOptionsBuilder<BankDbContext>()
//                .UseSqlServer("Server=.;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;")
//                .Options;

//            using var context = new BankDbContext(options);

//            bool exit = false;

//            while (!exit)
//            {
//                Console.Clear();

//                Console.WriteLine("===== National Bank Management System =====");
//                Console.WriteLine("1. Add Customer");
//                Console.WriteLine("2. Open Account");
//                Console.WriteLine("3. Update Account Status");
//                Console.WriteLine("4. Remove Account from Customer");
//                Console.WriteLine("5. List Customers with Accounts");
//                Console.WriteLine("0. Exit");
//                Console.Write("Choose an option: ");

//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        AddCustomer(context);
//                        break;

//                    case "2":
//                        OpenAccount(context);
//                        break;

//                    case "3":
//                        Console.WriteLine("Update Account Status");
//                        break;

//                    case "4":
//                        Console.WriteLine("Remove Account from Customer");
//                        break;

//                    case "5":
//                        Console.WriteLine("List Customers with Accounts");
//                        break;

//                    case "0":
//                        exit = true;
//                        break;

//                    default:
//                        Console.WriteLine("Invalid option.");
//                        break;
//                }

//                if (!exit)
//                {
//                    Console.WriteLine("\nPress any key to return to the menu...");
//                    Console.ReadKey();
//                }
//            }
//        }

//        static void AddCustomer(BankDbContext context)
//        {
//            Console.Write("Full Name: ");
//            string fullName = Console.ReadLine();

//            Console.Write("National ID: ");
//            string nationalId = Console.ReadLine();

//            Console.Write("Date of Birth (yyyy-MM-dd): ");
//            DateTime dateOfBirth;

//            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
//            {
//                Console.Write("Invalid date. Enter again: ");
//            }

//            Console.Write("Email: ");
//            string email = Console.ReadLine();

//            Console.Write("Phone Number: ");
//            string phoneNumber = Console.ReadLine();

//            Console.Write("Address: ");
//            string address = Console.ReadLine();

//            Console.Write("Customer Type (Individual/Business): ");
//            string customerType = Console.ReadLine();

//            while (customerType != "Individual" && customerType != "Business")
//            {
//                Console.Write("Enter Individual or Business: ");
//                customerType = Console.ReadLine();
//            }

//            var customer = new Customer
//            {
//                FullName = fullName,
//                NationalId = nationalId,
//                DateOfBirth = dateOfBirth,
//                Email = email,
//                PhoneNumber = phoneNumber,
//                Address = address,
//                CustomerType = customerType
//            };

//            context.Customers.Add(customer);
//            context.SaveChanges();

//            Console.WriteLine($"Customer added successfully. ID: {customer.Id}");
//        }

//        static void OpenAccount(BankDbContext context)
//        {
//            Console.Write("Account Number: ");
//            string accountNumber = Console.ReadLine();

//            if (context.Accounts.Any(a => a.AccountNumber == accountNumber))
//            {
//                Console.WriteLine("Account number already exists.");
//                return;
//            }

//            Console.Write("Account Type: ");
//            string accountType = Console.ReadLine();

//            Console.Write("Branch Code: ");
//            string branchCode = Console.ReadLine();

//            var branch = context.Branches.Find(branchCode);

//            if (branch == null)
//            {
//                Console.WriteLine("Branch not found.");
//                return;
//            }

//            Console.Write("Customer ID: ");
//            if (!int.TryParse(Console.ReadLine(), out int customerId))
//            {
//                Console.WriteLine("Invalid Customer ID.");
//                return;
//            }

//            var customer = context.Customers.Find(customerId);

//            if (customer == null)
//            {
//                Console.WriteLine("Customer not found.");
//                return;
//            }

//            Console.Write("Ownership Role (Primary/CoHolder): ");
//            string ownershipType = Console.ReadLine();

//            while (ownershipType != "Primary" && ownershipType != "CoHolder")
//            {
//                Console.Write("Enter Primary or CoHolder: ");
//                ownershipType = Console.ReadLine();
//            }

//            var account = new Account
//            {
//                AccountNumber = accountNumber,
//                AccountType = accountType,
//                CurrentBalance = 0,
//                OpeningDate = DateTime.Now,
//                BranchCode = branchCode
//            };

//            var customerAccount = new CustomerAccount
//            {
//                CustomerId = customerId,
//                AccountNumber = accountNumber,
//                OwnershipType = ownershipType,
//                OwnershipStartDate = DateTime.Now,
//                AccountStatus = "Active"
//            };

//            context.Accounts.Add(account);
//            context.CustomerAccounts.Add(customerAccount);
//            context.SaveChanges();

//            Console.WriteLine("Account opened successfully.");
//        }
//    }
//}
#endregion
