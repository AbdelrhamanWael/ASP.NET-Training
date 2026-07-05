# Bank Account System

A simple console-based banking application built with C# and .NET. This project demonstrates core Object-Oriented Programming (OOP) concepts, including classes, enums, basic data structures, and the separation of concerns.

## Features

- **Customer Management**: Create new customers with their personal details.
- **Account Management**: Create different types of accounts (Checking, Savings, Business) linked to specific customers.
- **Transactions**: Perform basic banking operations:
  - Deposit funds into an account.
  - Withdraw funds (with validation to prevent overdrafts).
  - Transfer funds securely between two accounts.
- **Account Statements**: Generate and view a comprehensive statement displaying an account's current balance, owner details, and a full transaction history.

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
