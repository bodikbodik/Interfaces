using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit , IProlongable
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period)
        {


        }
        public bool CanToProlong()
        {
            if (Amount > 1000)
            {
                return true;
            }
            return false;
        }

        public override decimal Income()
        {

            decimal tempAmount = Amount;

            for (int i = 1; i <= Period; i++)
            {
                tempAmount = tempAmount + tempAmount / 100 * i;

            }
            return tempAmount - Amount;

        }

    }
}
