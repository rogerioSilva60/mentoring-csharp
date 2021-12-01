using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.Exceptions
{
    public class Account
    {
        decimal Balance;

        public Account(decimal balance)
        {
            Balance = balance;
        }

        public void Withdraw(decimal value)
        {
            if(value > Balance)
            {
                throw new ArgumentException("Insufficient funds");
            }
            Balance -= value;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
