using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Stand
    {
        public Inventory inventory;
        public CashRegister cashRegister;

        public Stand()
        {
            inventory = new Inventory();
            cashRegister = new CashRegister();
        }
        public void MakeLemonade(int amountOfLemonadeToMake)
        {
                for (int i = 0; i < amountOfLemonadeToMake; i++)
                {
                    Lemonade lemonade = new Lemonade();
                    inventory.pitchersOfLemonade.Add(lemonade);
                    inventory.lemons.RemoveRange(0, 4);
                    inventory.cupsOfSugar.RemoveRange(0, 4);
                    inventory.iceCubes.RemoveRange(0, 50);
                }
        }

        public void Sell()
        {
            inventory.pitchersOfLemonade[0].cupsOfLemonade -= 1;
            inventory.cups.RemoveAt(0);
            inventory.pitchersOfLemonade[0].CheckIfFull(inventory);
        }

        public void SoldOut()
        {
            if (inventory.cups.Count == 0 && inventory.pitchersOfLemonade.Count == 0)
            {
                Console.WriteLine("You ran out of cups and lemonade.");
            }
            else if (inventory.cups.Count == 0)
            {
                Console.WriteLine("You ran out of cups and had to close for the day.");
            }
            else if (inventory.pitchersOfLemonade.Count == 0)
            {
                Console.WriteLine("You ran out of lemonade and had to close for the day.");
            }
        }



    }
}