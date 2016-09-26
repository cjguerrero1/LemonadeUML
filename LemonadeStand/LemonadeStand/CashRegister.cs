using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class CashRegister
    {
        public double cash;

        public CashRegister()
        {
            cash = 20.00;
        }

        public bool CheckIfEnoughFunds(double purchaseAmount)
        {
            if (cash - purchaseAmount >= 0)
            {
                cash -= purchaseAmount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintCash()
        {
            string cashOnHand = String.Format("{0:C}", cash);
            Console.WriteLine(cashOnHand);
        }

        public void ResetCash()
        {
            cash = 20.00;
        }
    }
}
