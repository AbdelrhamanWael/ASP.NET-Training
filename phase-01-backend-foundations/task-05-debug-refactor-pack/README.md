# Task 05 - Refactoring and Debugging

## Original Bad Code Issues
The original code in `OriginalBadCode.cs` suffered from several severe design and coding flaws:
- **No Separation of Concerns**: All UI (Console interaction) and business logic (calculations, tax, discount) were mixed together in a single `Main` method.
- **No Models**: Everything was handled using primitive types and variables. There were no representations for core entities like `Customer` and `Order`.
- **Magic Numbers**: Values like `0.05`, `0.10`, `0.15`, `0.14` (tax), `50` (shipping), and `1000` (free shipping threshold) were hardcoded directly in the logic, making them hard to understand and maintain.
- **Poor Naming Conventions**: Variables like `c`, `p`, `pr`, `q`, and `t` were extremely unclear and gave no context about their purpose.
- **No Input Validation**: If a user entered invalid text for the price or negative numbers for the quantity, the program would crash or produce illogical results.
- **Duplicate Logic**: The discount calculation had repetitive `else if` structures.

## Improvements Made
- **Created Models**: Introduced `Customer.cs` and `Order.cs` classes to encapsulate data.
- **Created `OrderCalculator`**: Moved all business rules (discount, tax, shipping, total) into a dedicated `OrderCalculator` class.
- **Added Input Validation**: `double.TryParse` and `int.TryParse` are now used to prevent crashes on invalid input, and we ensure quantity and price are positive numbers.
- **Replaced Magic Numbers with Constants**: Added `TaxRate`, `DefaultShippingCost`, and `FreeShippingThreshold` as constants in `OrderCalculator`.
- **Improved Naming**: Replaced `c` with `customer.Name`, `pr` with `price`, etc.
- **Improved Receipt Output**: Added a nicely formatted, user-friendly receipt output.

## Why the New Version is Better
The refactored code is much more **maintainable**, **readable**, and **testable**. Because business logic is isolated in `OrderCalculator`, we can easily write unit tests for it without needing a Console interface. If the tax rate changes, we only need to update a single constant rather than searching through the whole codebase. 

## Principles Applied
- **Separation of Concerns**: Separated the Console Input/Output from the core calculations.
- **Meaningful Naming**: Adopted clear names like `ProductName`, `OrderCalculator`, `CalculateDiscount`.
- **Removing Magic Numbers**: Using `const double` for static business values like `TaxRate` and `DefaultShippingCost`.
- **Input Validation**: Ensuring user input is valid before processing.
- **Method Extraction & Single Responsibility Principle**: The `OrderCalculator` focuses strictly on calculations, while models strictly hold data. Each method in the calculator performs exactly one calculation.
- **Replacing Repeated Conditions**: Streamlined the discount condition using a cleaner `switch` statement instead of repeated `else if`.
