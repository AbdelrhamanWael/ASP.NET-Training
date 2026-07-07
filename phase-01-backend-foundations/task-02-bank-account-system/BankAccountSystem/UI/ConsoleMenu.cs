using System;
using BankAccountSystem.Models;
using BankAccountSystem.Services;

namespace BankAccountSystem.UI
{
    public class ConsoleMenu
    {
        private BankService _bankService;

        public ConsoleMenu()
        {
            _bankService = new BankService();
            // Seed some data for convenience
            var customer = _bankService.CreateCustomer("John Doe", "john@example.com", "1234567890");
            _bankService.CreateAccount(customer, AccountType.Checking, 500m);
        }

        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n====== TechMaster Bank System ======");
                Console.WriteLine("1. Create Customer Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Transfer Money");
                Console.WriteLine("5. View Account Details");
                Console.WriteLine("6. View Transaction History");
                Console.WriteLine("7. View All Accounts");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            CreateCustomerAccountUI();
                            break;
                        case "2":
                            DepositMoneyUI();
                            break;
                        case "3":
                            WithdrawMoneyUI();
                            break;
                        case "4":
                            TransferMoneyUI();
                            break;
                        case "5":
                            ViewAccountDetailsUI();
                            break;
                        case "6":
                            ViewTransactionHistoryUI();
                            break;
                        case "7":
                            ViewAllAccountsUI();
                            break;
                        case "8":
                            exit = true;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void CreateCustomerAccountUI()
        {
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            var customer = _bankService.CreateCustomer(name, email, phone);
            Console.WriteLine($"Customer created successfully with ID: {customer.Id}");

            Console.WriteLine("Select Account Type (1: Checking, 2: Savings, 3: Business): ");
            string typeInput = Console.ReadLine();
            AccountType type = AccountType.Checking;
            if (typeInput == "2") type = AccountType.Savings;
            else if (typeInput == "3") type = AccountType.Business;

            Console.Write("Enter Initial Deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
            {
                var account = _bankService.CreateAccount(customer, type, initialDeposit);
                Console.WriteLine($"Account created successfully! Account Number: {account.AccountNumber}");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        private void DepositMoneyUI()
        {
            Console.Write("Enter Account Number: ");
            string accNum = Console.ReadLine();
            Console.Write("Enter Amount to Deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                _bankService.Deposit(accNum, amount, "Deposit via Console");
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        private void WithdrawMoneyUI()
        {
            Console.Write("Enter Account Number: ");
            string accNum = Console.ReadLine();
            Console.Write("Enter Amount to Withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                _bankService.Withdraw(accNum, amount, "Withdrawal via Console");
                Console.WriteLine("Withdrawal successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        private void TransferMoneyUI()
        {
            Console.Write("Enter From Account Number: ");
            string fromAcc = Console.ReadLine();
            Console.Write("Enter To Account Number: ");
            string toAcc = Console.ReadLine();
            Console.Write("Enter Amount to Transfer: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                _bankService.Transfer(fromAcc, toAcc, amount);
                Console.WriteLine("Transfer successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        private void ViewAccountDetailsUI()
        {
            Console.Write("Enter Account Number: ");
            string accNum = Console.ReadLine();
            var account = _bankService.GetAccount(accNum);
            if (account != null)
            {
                Console.WriteLine($"\n--- Account Details ---");
                Console.WriteLine($"Account Number: {account.AccountNumber}");
                Console.WriteLine($"Owner: {account.AccountOwner.FullName}");
                Console.WriteLine($"Type: {account.Type}");
                Console.WriteLine($"Balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private void ViewTransactionHistoryUI()
        {
            Console.Write("Enter Account Number: ");
            string accNum = Console.ReadLine();
            var account = _bankService.GetAccount(accNum);
            if (account != null)
            {
                Console.WriteLine($"\n--- Transaction History for Account: {account.AccountNumber} ---");
                foreach (var t in account.Transactions)
                {
                    Console.WriteLine($"[{t.TransactionDate}] {t.Type} - {t.Amount:C} | Balance: {t.BalanceAfter:C} | {t.Description}");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private void ViewAllAccountsUI()
        {
            var accounts = _bankService.GetAllAccounts();
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            Console.WriteLine("\n--- All Accounts ---");
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account: {account.AccountNumber} | Owner: {account.AccountOwner.FullName} | Type: {account.Type} | Balance: {account.Balance:C}");
            }
        }
    }
}
