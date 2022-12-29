using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class LongDeposit : Deposit , IProlongable
    {
        public LongDeposit(decimal amount, int period) : base(amount, period)
        {

        }
        public bool CanToProlong()
        {
            if (Period <= 36)
            {
                return true;
            }
            return false;
        }

        public override decimal Income()
        {
            decimal tempAmount = Amount;

            for (int i = 7; i <= Period; i++)
            {
                tempAmount = tempAmount + tempAmount / 100 * 15;

            }
            return tempAmount - Amount;
        }

    }
}
