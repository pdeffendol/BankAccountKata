using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace BankAccountApp.Tests
{
    public class AccountServiceTests
    {
        private readonly AccountService _accountService;
        private readonly Mock<ITransactionRepository> _transactionRepository;
        private readonly Mock<IStatementPrinter> _statementPrinter;

        public AccountServiceTests()
        {
            _transactionRepository = new Mock<ITransactionRepository>();
            _statementPrinter = new Mock<IStatementPrinter>();
            _accountService = new AccountService(_transactionRepository.Object, _statementPrinter.Object);
        }

        [Fact]
        public void Deposit_StoresADepositTransaction()
        {
            _accountService.Deposit(500);
            _transactionRepository.Verify(r => r.AddDeposit(500), Times.Once);
        }

        [Fact]
        public void Withdraw_StoresAWithdrawalTransaction()
        {
            _accountService.Withdraw(100);
            _transactionRepository.Verify(r => r.AddWithdrawal(100), Times.Once);
        }

        [Fact]
        public void PrintStatement_PrintsTransactions()
        {
            var transactions = new List<Transaction>()
            {
                Deposit("02/01/2020", 500),
                Withdrawal("02/02/2020", 100),
                Deposit("03/01/2020", 300)
            };
            _transactionRepository.Setup(r => r.GetAll()).Returns(transactions);

            _accountService.PrintStatement();

            _statementPrinter.Verify(p => p.Print(transactions));
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
