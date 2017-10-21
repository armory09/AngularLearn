namespace CrankBank.Models
{
    public class AccountDetail
    {
        public AccountSummary AccountSummary { get; set; }
        public AccountTransaction[] AccountTransactions { get; set; }
    }
}
