
using Microsoft.EntityFrameworkCore;
using NationalBankManagementSystem.Data;
using NationalBankManagementSystem.Models;

namespace NationalBankManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<BankDbContext>()
                .UseSqlServer("Server=.;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using var context = new BankDbContext(options);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("===== National Bank Management System =====");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Open Account");
                Console.WriteLine("3. Update Account Status");
                Console.WriteLine("4. Remove Account from Customer");
                Console.WriteLine("5. List Customers with Accounts");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddCustomer(context);
                            break;

                        case "2":
                            OpenAccount(context);
                            break;

                        case "3":
                            UpdateAccountStatus(context);
                            break;

                        case "4":
                            RemoveAccountFromCustomer(context);
                            break;

                        case "5":
                            ListCustomersWithAccounts(context);
                            break;

                        case "0":
                            exit = true;
                            Console.WriteLine("Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Operation failed: {ex.Message}");
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        static string ReadRequiredInput(string message)
        {
            string value;

            do
            {
                Console.Write(message);
                value = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("This field is required.");

            } while (string.IsNullOrWhiteSpace(value));

            return value.Trim();
        }

        static void AddCustomer(BankDbContext context)
        {
            Console.WriteLine("\n===== Add Customer =====");

            string fullName = ReadRequiredInput("Full Name: ");
            string nationalId = ReadRequiredInput("National ID: ");

            DateTime dateOfBirth;

            Console.Write("Date of Birth (yyyy-MM-dd): ");

            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.Write("Invalid date. Enter again (yyyy-MM-dd): ");
            }

            string email = ReadRequiredInput("Email: ");
            string phoneNumber = ReadRequiredInput("Phone Number: ");
            string address = ReadRequiredInput("Address: ");

            string customerType = ReadRequiredInput(
                "Customer Type (Individual/Business): ");

            while (!customerType.Equals("Individual", StringComparison.OrdinalIgnoreCase)
                && !customerType.Equals("Business", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter Individual or Business: ");
                customerType = Console.ReadLine() ?? "";
            }

            var customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                CustomerType = customerType
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            Console.WriteLine($"Customer added successfully. ID: {customer.Id}");
        }

        static void OpenAccount(BankDbContext context)
        {
            Console.WriteLine("\n===== Open Account =====");

            string accountNumber = ReadRequiredInput("Account Number: ");

            if (context.Accounts.Any(a => a.AccountNumber == accountNumber))
            {
                Console.WriteLine("Account number already exists.");
                return;
            }

            string accountType = ReadRequiredInput("Account Type: ");
            string branchCode = ReadRequiredInput("Branch Code: ");

            var branch = context.Branches.Find(branchCode);

            if (branch == null)
            {
                Console.WriteLine("Branch not found.");
                return;
            }

            Console.Write("Customer ID: ");

            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer ID.");
                return;
            }

            var customer = context.Customers.Find(customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            string ownershipType = ReadRequiredInput(
                "Ownership Role (Primary/CoHolder): ");

            while (!ownershipType.Equals("Primary", StringComparison.OrdinalIgnoreCase)
                && !ownershipType.Equals("CoHolder", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter Primary or CoHolder: ");
                ownershipType = Console.ReadLine() ?? "";
            }

            var account = new Account
            {
                AccountNumber = accountNumber,
                AccountType = accountType,
                CurrentBalance = 0,
                OpeningDate = DateTime.Now,
                BranchCode = branchCode
            };

            var customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                OwnershipType = ownershipType,
                OwnershipStartDate = DateTime.Now,
                AccountStatus = "Active"
            };

            context.Accounts.Add(account);
            context.CustomerAccounts.Add(customerAccount);
            context.SaveChanges();

            Console.WriteLine("Account opened successfully.");
        }

        static void UpdateAccountStatus(BankDbContext context)
        {
            Console.WriteLine("\n===== Update Account Status =====");

            string accountNumber = ReadRequiredInput("Account Number: ");

            Console.Write("Customer ID: ");

            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer ID.");
                return;
            }

            var customerAccount = context.CustomerAccounts
                .Find(customerId, accountNumber);

            if (customerAccount == null)
            {
                Console.WriteLine("Account not found for this customer.");
                return;
            }

            customerAccount.AccountStatus =
                customerAccount.AccountStatus == "Active"
                    ? "Inactive"
                    : "Active";

            context.SaveChanges();

            Console.WriteLine(
                $"Account status updated successfully. New Status: {customerAccount.AccountStatus}");
        }

        static void RemoveAccountFromCustomer(BankDbContext context)
        {
            Console.WriteLine("\n===== Remove Account from Customer =====");

            string accountNumber = ReadRequiredInput("Account Number: ");

            Console.Write("Customer ID: ");

            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer ID.");
                return;
            }

            var customerAccount = context.CustomerAccounts
                .Find(customerId, accountNumber);

            if (customerAccount == null)
            {
                Console.WriteLine("Account not found for this customer.");
                return;
            }

            context.CustomerAccounts.Remove(customerAccount);
            context.SaveChanges();

            Console.WriteLine("Account removed from customer successfully.");
        }

        static void ListCustomersWithAccounts(BankDbContext context)
        {
            Console.WriteLine("\n===== Customers with Accounts =====");

            var customers = context.Customers
                .Include(c => c.CustomerAccounts)
                .ThenInclude(ca => ca.Account)
                .ToList();

            if (!customers.Any())
            {
                Console.WriteLine("No customers found.");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine("\n----------------------------------");
                Console.WriteLine($"Customer ID: {customer.Id}");
                Console.WriteLine($"Name: {customer.FullName}");
                Console.WriteLine($"National ID: {customer.NationalId}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone: {customer.PhoneNumber}");
                Console.WriteLine($"Customer Type: {customer.CustomerType}");

                if (!customer.CustomerAccounts.Any())
                {
                    Console.WriteLine("No accounts.");
                    continue;
                }

                Console.WriteLine("Accounts:");

                foreach (var customerAccount in customer.CustomerAccounts)
                {
                    Console.WriteLine($"Account Number: {customerAccount.AccountNumber}");
                    Console.WriteLine($"Account Type: {customerAccount.Account.AccountType}");
                    Console.WriteLine($"Ownership: {customerAccount.OwnershipType}");
                    Console.WriteLine($"Status: {customerAccount.AccountStatus}");
                }
            }
        }
    }
}
