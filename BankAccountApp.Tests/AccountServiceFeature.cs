using Xunit;
using Moq;
using System.Collections.Generic;

namespace BankAccountApp.Tests
{
    public class AccountServiceFeature
    {
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;
        private readonly Mock<IConsole> _consoleMock;
        private readonly AccountService _accountService;

        public AccountServiceFeature()
        {
            _dateTimeProviderMock = new Mock<IDateTimeProvider>();
            _consoleMock = new Mock<IConsole>();
            _accountService = new AccountService(new TransactionRepository(_dateTimeProviderMock.Object), new StatementPrinter(_consoleMock.Object));
        }

        [Fact]
        public void PrintStatement_ContainsAllTransactions()
        {
            _dateTimeProviderMock.SetupSequence(d => d.FormattedCurrentDate)
                .Returns("01/01/2020")
                .Returns("02/01/2020")
                .Returns("02/20/2020");

            var lines = new List<string>();
            _consoleMock.Setup(c => c.WriteLine(It.IsAny<string>()))
                .Callback<string>(line => lines.Add(line));

            _accountService.Deposit(1000);
            _accountService.Withdraw(100);
            _accountService.Deposit(500);
            _accountService.PrintStatement();

            Assert.Equal(4, lines.Count);
            Assert.Equal("DATE | AMOUNT | BALANCE", lines[0]);
            Assert.Equal("02/20/2020 | 500.00 | 1400.00", lines[1]);
            Assert.Equal("02/01/2020 | -100.00 | 900.00", lines[2]);
            Assert.Equal("01/01/2020 | 1000.00 | 1000.00", lines[3]);
        }
    }
}
