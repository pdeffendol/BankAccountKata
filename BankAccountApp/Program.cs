using System;

namespace BankAccountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountService = new AccountService(
                new TransactionRepository(new SystemDateTimeProvider()),
                new StatementPrinter(new Console()));

            accountService.Deposit(1000);
            accountService.Withdraw(300);
            accountService.Deposit(500);
            accountService.PrintStatement();
        }
    }
}
