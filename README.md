# Bank Account Kata

This is an implementation of a simple bank account code kata in C# and .NET Core.

It is recommended to use test-driven development to drive out your design.

## Goal

Create an `AccountService` class that has the following methods:

1. `void Deposit(int amount)`
2. `void Withdraw(int amount)`
3. `void PrintStatement()`

Given the following code snippet:

```csharp
accountService.Deposit(1000);
accountService.Withdraw(300);
accountService.Deposit(500);
accountService.PrintStatement();
```

you should get output similar to:

```
DATE | AMOUNT | BALANCE
01/02/2020 | 500.00 | 1200.00
02/01/2020 | -300.00 | 700.00
03/01/2020 | 1000.00 | 1000.00
```

## Rules

* You cannot add any additional public methods to `AccountService` or change the method signatures as described above.
* You may create any other classes needed to fulfil the requirements.
* You do not need to align the columns in the output.
* When printing the statement, the output should list transactions in reverse chronological order, with the running balance on each line.

