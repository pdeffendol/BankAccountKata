using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountApp
{
    public interface IStatementPrinter
    {
        void Print(IReadOnlyList<Transaction> transactions);
    }
}
