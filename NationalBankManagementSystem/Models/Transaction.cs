
namespace NationalBankManagementSystem.Models
{
    public class Transaction
    {
        public int TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public Account Account { get; set; } = null!;
    }
}
