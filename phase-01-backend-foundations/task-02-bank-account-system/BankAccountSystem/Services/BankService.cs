using System;
using System.Collections.Generic;
using System.Linq;
using BankAccountSystem.Models;

namespace BankAccountSystem.Services
{
    public class BankService
    {
        private List<BankAccount> _accounts;
        private List<Customer> _customers;
        private int _customerCounter = 1;
        private int _accountCounter = 1000;

        public BankService()
        {
            _accounts = new List<BankAccount>();
            _customers = new List<Customer>();
        }

        public Customer CreateCustomer(string fullName, string email, string phoneNumber)
        {
            var customer = new Customer
            {
                Id = _customerCounter++,
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                CreatedAt = DateTime.Now
            };
            _customers.Add(customer);
            return customer;
        }

        public BankAccount CreateAccount(Customer customer, AccountType type, decimal initialBalance)
        {
            var account = new BankAccount(_accountCounter++.ToString(), customer, type, initialBalance);
            _accounts.Add(account);
            return account;
        }

        public BankAccount GetAccount(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void Deposit(string accountNumber, decimal amount, string description)
        {
            var account = GetAccount(accountNumber);
            if (account == null) throw new Exception("Account not found.");
            account.Deposit(amount, description);
        }

        public void Withdraw(string accountNumber, decimal amount, string description)
        {
            var account = GetAccount(accountNumber);
            if (account == null) throw new Exception("Account not found.");
            account.Withdraw(amount, description);
        }

        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = GetAccount(fromAccountNumber);
            var toAccount = GetAccount(toAccountNumber);

            if (fromAccount == null || toAccount == null) throw new Exception("One or both accounts not found.");

            fromAccount.Withdraw(amount, $"Transfer to {toAccountNumber}");
            toAccount.Deposit(amount, $"Transfer from {fromAccountNumber}");
        }

        public void PrintStatement(string accountNumber)
        {
            var account = GetAccount(accountNumber);
            if (account == null) throw new Exception("Account not found.");

            Console.WriteLine($"\n--- Statement for Account: {account.AccountNumber} ---");
            Console.WriteLine($"Owner: {account.AccountOwner.FullName}");
            Console.WriteLine($"Type: {account.Type}");
            Console.WriteLine($"Current Balance: {account.Balance:C}\n");

            Console.WriteLine("Transactions:");
            foreach (var t in account.Transactions)
            {
                Console.WriteLine($"[{t.TransactionDate}] {t.Type} - {t.Amount:C} | Balance: {t.BalanceAfter:C} | {t.Description}");
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}
