using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
        }
        public int balance { get; set; }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            var temp = _logBook.LogSeverity;

            balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            _logBook.Message("Withdraw invoked");
            if (amount <= balance)
            {
                _logBook.LogToDb("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                return _logBook.LogBalanceAfterWithDrawal(balance);
            }
          
            return _logBook.LogBalanceAfterWithDrawal(balance-amount);


        }
            
        public int GetBalance() { return balance; }
    }
}
