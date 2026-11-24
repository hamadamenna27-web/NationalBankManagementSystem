
namespace NationalBankManagementSystem.Models
{
    public class Branch
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public Manager Manager { get; set; } = null!;
    }
}
