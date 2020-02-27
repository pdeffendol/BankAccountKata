using Xunit;
using Moq;

namespace BankAccountApp.Tests
{
    public class TransactionRepositoryTests
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;

        public TransactionRepositoryTests()
        {
            _dateTimeProviderMock = new Mock<IDateTimeProvider>();
            _transactionRepository = new TransactionRepository(_dateTimeProviderMock.Object);
        }

        [Fact]
        public void AddDeposit_CreatesANewDeposit()
        {
            _dateTimeProviderMock.SetupGet(d => d.FormattedCurrentDate).Returns("01/01/2020");

            _transactionRepository.AddDeposit(100);

            var transactions = _transactionRepository.GetAll();
            Assert.Single(transactions);
            Assert.Equal(100, transactions[0].Amount);
            Assert.Equal("01/01/2020", transactions[0].Date);
        }

        [Fact]
        public void AddWithdrawal_CreatesANewWithdrawal()
        {
            _dateTimeProviderMock.SetupGet(d => d.FormattedCurrentDate).Returns("01/01/2020");

            _transactionRepository.AddWithdrawal(100);

            var transactions = _transactionRepository.GetAll();
            Assert.Single(transactions);
            Assert.Equal(-100, transactions[0].Amount);
            Assert.Equal("01/01/2020", transactions[0].Date);
        }

        [Fact]
        public void GetAll_WithEmptyRepository_ReturnsEmptyList()
        {
            Assert.Empty(_transactionRepository.GetAll());
        }
    }
}