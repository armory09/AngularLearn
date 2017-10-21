namespace CrankBank.Models
{
    public class AccountSummary
    {
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
