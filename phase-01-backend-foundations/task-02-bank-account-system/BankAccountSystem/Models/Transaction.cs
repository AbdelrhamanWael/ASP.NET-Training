using System;

namespace BankAccountSystem.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public decimal BalanceAfter { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction(decimal amount, TransactionType type, string description, decimal balanceAfter, DateTime transactionDate)
        {
            TransactionId = Guid.NewGuid();
            Amount = amount;
            Type = type;
            Description = description;
            BalanceAfter = balanceAfter;
            TransactionDate = transactionDate;
        }
    }
}