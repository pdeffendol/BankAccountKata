using System.Collections.Generic;

namespace BankAccountApp
{
    public interface ITransactionRepository
    {
        public void AddDeposit(int amount);
        public void AddWithdrawal(int amount);
        public IReadOnlyList<Transaction> GetAll();
    }
}