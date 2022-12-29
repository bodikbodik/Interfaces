using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }
        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < 10; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }
            return false;
        }

        public decimal TotalIncome()
        {
            decimal sum = 0m;
            for (int i = 0; i < 10; i++)
            {
                if (deposits[i] != null)
                {

                    sum += deposits[i].Income();
                }
            }
            return sum;
        }
        public decimal MaxIncome()
        {
            decimal maxIncome = deposits[0].Income();
            foreach (Deposit s in deposits)
            {
                if (s != null && maxIncome < s.Income())
                {
                    maxIncome = s.Income();
                }
            }
            return maxIncome;
        }
        public decimal GetIncomeByNumber(int number)
        {
            if (deposits[number - 1] != null)
                return deposits[number - 1].Income();
            else
                return 0m;

        }
        public void SortDeposits()
        {
            Array.Sort(deposits);
            Array.Reverse(deposits);
        }
        public int CountPossibleToProlongDeposit()
        {
            int count = 0;
            foreach (Deposit deposit in deposits)
            {
                if(deposit is IProlongable prolongable && prolongable.CanToProlong())
                    count++;
            }
            return count;
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            return ((IEnumerable<Deposit>)deposits).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return deposits.GetEnumerator();
        }
    }
}
