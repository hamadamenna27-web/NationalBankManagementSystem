
namespace NationalBankManagementSystem.Models
{
    public class Account
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public string AccountType { get; set; } = string.Empty;
        public DateTime OpeningDate { get; set; }
        public string BranchCode { get; set; } = string.Empty;

        public Branch Branch { get; set; } = null!;

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
            = new List<CustomerAccount>();

        public ICollection<Transaction> Transactions { get; set; }
            = new List<Transaction>();
    }
}
