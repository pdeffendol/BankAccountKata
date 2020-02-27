using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace BankAccountApp.Tests
{
    public class StatementPrinterTests
    {
        private readonly StatementPrinter _statementPrinter;
        private readonly Mock<IConsole> _console;

        private readonly IReadOnlyList<Transaction> _noTransactions = new List<Transaction>();

        public StatementPrinterTests()
        {
            _console = new Mock<IConsole>();
            _statementPrinter = new StatementPrinter(_console.Object);
        }

        [Fact]
        public void Print_AlwaysPrintsHeader()
        {
            _statementPrinter.Print(_noTransactions);
            _console.Verify(c => c.WriteLine("DATE | AMOUNT | BALANCE"));
            _console.VerifyNoOtherCalls();
        }

        [Fact]
        public void Print_PrintsTransactionsInReverseDateOrder()
        {
            var transactions = new List<Transaction>()
            {
                Deposit("02/01/2020", 500),
                Withdrawal("02/02/2020", 100),
                Deposit("03/01/2020", 300)
            };

            List<string> lines = new List<string>();
            _console.Setup(c => c.WriteLine(It.IsAny<string>())).Callback<string>(line => lines.Add(line));

            _statementPrinter.Print(transactions);

            Assert.Equal(4, lines.Count);
            Assert.Equal("DATE | AMOUNT | BALANCE", lines[0]);
            Assert.Equal("03/01/2020 | 300.00 | 700.00", lines[1]);
            Assert.Equal("02/02/2020 | -100.00 | 400.00", lines[2]);
            Assert.Equal("02/01/2020 | 500.00 | 500.00", lines[3]);
        }

        private Transaction Deposit(string date, int amount)
        {
            return new Transaction(date, amount);
        }

        private Transaction Withdrawal(string date, int amount)
        {
            return new Transaction(date, -amount);
        }
    }
}
