using System;

namespace CrankBank.Models
{
    public class AccountTransaction
    {
        public DateTimeOffset TransactionDate { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
