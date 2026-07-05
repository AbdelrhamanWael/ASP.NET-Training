using System;
using System.Collections.Generic;

namespace BankAccountSystem.Models
{
    public class BankAccount
    {
        //. AccountNumber
        public string AccountNumber { get; set; }


        // . Customer
        public Customer AccountOwner { get; set; }

        // * Balance
        public decimal Balance { get; set; }

        // . AccountType
        public string Type { get; set; }

        // . CreatedAt
        public DateTime CreatedAt { get; set; }

        // . IsActive
        public bool IsActive { get; set; }

        //. Transactions
        public List<Transaction> Transactions  = new List<Transaction>();
        public BankAccount(string accountNumber, Customer owner, AccountType type , decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountOwner = owner;
            Type = type.ToString();
            Balance = initialBalance;
            CreatedAt = DateTime.Now;
            IsActive = true;
            Transactions = new List<Transaction>();

            if (initialBalance > 0)
            {
                Deposit(initialBalance , "Initial Deposit");
            }
        }

        public void Deposit(decimal amount, string description = "Deposit")
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

            Balance += amount;
            Transactions.Add(new Transaction(amount, TransactionType.Deposit, description, Balance, DateTime.Now));
        }

        public void  Withdraw(decimal amount, string description = "Withdrawal")
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if(amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            Balance -= amount;
            Transactions.Add(new Transaction(amount, TransactionType.Withdrawal, description, Balance, DateTime.Now));
        }

    }
}