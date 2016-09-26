using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        public Stand stand;

        public Player()
        {
           stand = new Stand();
        }

        public void BuyLemons()
        {
            Console.WriteLine("Enter number of lemons to buy($.10 each): ");
            double amountOfLemons = double.Parse(Console.ReadLine());
            bool canBuyLemons = stand.cashRegister.CheckIfEnoughFunds(amountOfLemons * .10);
            if (canBuyLemons)
            {
                for (int i = 0; i < amountOfLemons; i++)
                {
                    Lemon lemon = new Lemon();
                    stand.inventory.lemons.Add(lemon);
                }
                stand.cashRegister.PrintCash();
            }
            else
            {
                Console.WriteLine("You don't have enough money for that many lemons.");
                BuyLemons();
            }
        }

        public void BuyIce()
        {
            Console.WriteLine("Enter number of ice cubes to buy($.01 each): ");
            double amountOfIce = double.Parse(Console.ReadLine());
            bool canBuyIce = stand.cashRegister.CheckIfEnoughFunds(amountOfIce * .01);
            if (canBuyIce)
            {
                for (int i = 0; i < amountOfIce; i++)
                {
                    Ice ice = new Ice();
                    stand.inventory.iceCubes.Add(ice);
                }
                stand.cashRegister.PrintCash();
            }
            else
            {
                Console.WriteLine("You don't have enough money for that many ice cubes.");
                BuyIce();
            }
        }

        public void BuySugar()
        {
            Console.WriteLine("Enter number of cups of sugar to buy($.10 each): ");
            double amountOfSugar = double.Parse(Console.ReadLine());
            bool canBuySugar = stand.cashRegister.CheckIfEnoughFunds(amountOfSugar * .10);
            if (canBuySugar)
            {
                for (int i = 0; i < amountOfSugar; i++)
                {
                    Sugar sugar = new Sugar();
                    stand.inventory.cupsOfSugar.Add(sugar);
                }
                stand.cashRegister.PrintCash();
            }
            else
            {
                Console.WriteLine("You don't have enough money for that many cups of sugar.");
                BuySugar();
            }
        }

        public void BuyCups()
        {
            Console.WriteLine("Enter number of cups to buy($.05 each): ");
            int amountOfCups = int.Parse(Console.ReadLine());
            bool canBuyCups = stand.cashRegister.CheckIfEnoughFunds(amountOfCups * .05);
            if (canBuyCups)
            {
                for (int i = 0; i < amountOfCups; i++)
                {
                    Cup cup = new Cup();
                    stand.inventory.cups.Add(cup);
                }
                stand.cashRegister.PrintCash();
            }
            else
            {
                Console.WriteLine("You don't have enough money for that many cups.");
                BuyCups();
            }
        }
    }
}
