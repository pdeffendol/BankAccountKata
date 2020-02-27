namespace BankAccountApp
{
    public class AccountService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _statementPrinter;

        public AccountService(ITransactionRepository transactionRepository, IStatementPrinter statementPrinter)
        {
            _transactionRepository = transactionRepository;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.AddWithdrawal(amount);
        }

        public void PrintStatement()
        {
            _statementPrinter.Print(_transactionRepository.GetAll());
        }
    }
}