using System;
using Xunit;
using Moq;

namespace BankAccountApp.Tests
{
    public class AccountServiceFeature
    {
        private readonly AccountService _accountService;

        public AccountServiceFeature()
        {
            _accountService = new AccountService();
        }

        [Fact]
        public void PrintStatement_ContainsAllTransactions()
        {
            var console = new Mock<IConsole>();

            _accountService.Deposit(1000);
            _accountService.Withdraw(100);
            _accountService.Deposit(500);
            _accountService.PrintStatement();

            console.Verify(c => c.WriteLine("Date | Amount | Balance"));
            console.Verify(c => c.WriteLine("02/20/2020 | 500.00 | 1400.00"));
            console.Verify(c => c.WriteLine("02/01/2020 | -100.00 | 900.00"));
            console.Verify(c => c.WriteLine("01/01/2020 | 1000.00 | 1000.00"));
        }
    }
}
