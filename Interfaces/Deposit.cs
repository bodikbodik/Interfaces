using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }
        public Deposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }
        public abstract decimal Income();
        public int CompareTo(Deposit other)
        {
            if (other == null) return 1;
            if (Amount + Income() < other.Amount + other.Income()) return -1;
            if (Amount + Income() > other.Amount + other.Income()) return 1;
            return 0;
        }
       
    }
}
