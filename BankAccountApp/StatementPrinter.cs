using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankAccountApp
{
    public class StatementPrinter : IStatementPrinter
    {
        private readonly IConsole _console;

        private const string StatementHeader = "DATE | AMOUNT | BALANCE";
        private const string NumberFormat = "0.00";

        public StatementPrinter(IConsole console)
        {
            _console = console;
        }

        public void Print(IReadOnlyList<Transaction> transactions)
        {
            _console.WriteLine(StatementHeader);

            int balance = 0;
            transactions
                .Select(t =>
                {
                    balance += t.Amount;
                    return $"{t.Date} | {t.Amount.ToString(NumberFormat)} | {balance.ToString(NumberFormat)}";
                })
                .Reverse()
                .ToList()
                .ForEach(_console.WriteLine);
        }
    }
}
