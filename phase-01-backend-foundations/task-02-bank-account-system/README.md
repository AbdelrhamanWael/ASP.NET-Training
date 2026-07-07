# Bank Account System

A simple console-based banking application built with C# and .NET. This project demonstrates core Object-Oriented Programming (OOP) concepts, including classes, enums, basic data structures, and the separation of concerns.

## Features

- **Customer & Account Creation**: Seamlessly create new customers and associate different account types (Checking, Savings, Business) in one workflow.
- **Deposit & Withdraw Funds**: Perform basic transactions with validation to ensure sufficient balances.
- **Fund Transfers**: Securely transfer money between any two existing accounts.
- **View Account Details**: Quickly view current balance and ownership details for a specific account.
- **View Transaction History**: Access a complete historical log of all activities on an account.
- **View All Accounts**: Display a summarized list of all active accounts in the system.

## Project Structure

The project follows a modular architecture separating data, logic, and presentation:

- **Models/**: Contains the core data entities (`BankAccount`, `Customer`, `Transaction`, `TransactionType`, `AccountType`).
- **Services/**: Contains `BankService.cs` which acts as the central business logic layer orchestrating all operations (in-memory state management, ID generation, transfers, etc.).
- **UI/**: Contains `ConsoleMenu.cs`, a simple text-based interface for interacting with the service layer.
- **Program.cs**: The entry point of the application.

## How to Run

1. Open your terminal.
2. Navigate to the project directory:
   ```powershell
   cd phase-01-backend-foundations\task-02-bank-account-system\BankAccountSystem
   ```
3. Run the application:
   ```powershell
   dotnet run
   ```
