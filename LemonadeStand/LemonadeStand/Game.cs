using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{ 
    public class Game
    {
        Player player = new Player();
        string[] daysInAWeek = new string[] { "Monday:", "Tuesday:", "Wednesday:", "Thursday:", "Friday:", "Saturday:", "Sunday:" };
        public void PrintRules()
        {
            Console.WriteLine("Welcome to your Lemonade Stand. The object is simple, make as much money as possible in one week.");
            Console.WriteLine("Every day you will need to buy supplies for your stand and make new lemonade for the day.");
            Console.WriteLine("Each pitcher of lemonade makes 10 cups and requires 4 lemons, 4 cups of sugar, and 50 ice cubes.");
            Console.WriteLine("Weather will greatly affect how much the customers want lemonade, and how much they are willing to spend.");
            Console.WriteLine("Adjust your price per glass accordingly. You get ${0} to start with. Good Luck!", player.stand.cashRegister.cash);
            Console.ReadKey();
            Console.Clear();
        }
        
       public void NewDay()
        {
            Day day = new Day();
            player.stand.inventory.DisplayInventory();
            NeedSupplies();
            day.CustomersPassStand(player, day);
            player.stand.SoldOut();
            day.EndDay();
            player.stand.inventory.DisplayInventory();
            player.stand.cashRegister.PrintCash();
            Console.ReadKey();
            player.stand.inventory.Melt();
            player.stand.inventory.DumpOldLemonade();
            Console.ReadKey();
            Console.Clear();    
        }

        public void PlayGame()
        {
            PrintRules();
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(daysInAWeek[i]);
                NewDay();
            }
            DisplayScore();
            PlayAgain();
        }

        public void DoneStocking()
        {
            Console.WriteLine("Are you done buying supplies for today(y/n)? ");
            string response = Console.ReadLine();
            if (response == "n")
            {
                Console.Clear();
                BuySupplies();
            }

        }
        public void BuySupplies()
        {
            player.BuyCups();
            player.BuyIce();
            player.BuyLemons();
            player.BuySugar();
            DoneStocking();
            GetAmountOfLemonadeForDay();
            Console.Clear();
        }

         public void DisplayScore()
            {
                double score = player.stand.cashRegister.cash - 20.00;
                string totalScore = String.Format("{0:C}", score);
                if (score >= 15)
                {
                    Console.WriteLine("Congrats, you made {0}. That's great!", totalScore);
                }
                else if (score >= 7 && score < 15)
                {
                    Console.WriteLine("Congrats, you made {0}. That's pretty good.", totalScore);
                }
                else if (score > 0 && score <7)
                {
                    Console.WriteLine("You made {0}. I bet you could do better.", totalScore);
                }
                else if (score <= 0)
                {
                    Console.WriteLine("You didn't make any money, try again.");
                }
                Console.ReadKey();
           
            }

            public void PlayAgain()
            {
                Console.WriteLine("Would you like to play again or continue?");
                string playAgain = Console.ReadLine();
                switch (playAgain.ToLower())
                {
                    case "play again":
                        Console.Clear();
                        player.stand.inventory.ResetInventory();
                        player.stand.cashRegister.ResetCash();
                        PlayGame();
                        break;
                    case "continue":
                        Console.Clear();
                        PlayGame();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                        Console.ReadKey();
                        break;
                    
                }
            }

        public void NeedSupplies()
        {
            Console.WriteLine("Do you want to buy supplies(y/n)?");
            string needSupplies = Console.ReadLine();
            switch (needSupplies.ToLower())
            {
                case "y":
                    Console.Clear();
                    player.stand.inventory.DisplayInventory();
                    BuySupplies();
                    break;
                default:
                    Console.Clear();
                    GetAmountOfLemonadeForDay();
                    break;
            }
        }
        public void GetAmountOfLemonadeForDay()
        {
            Console.WriteLine("Enter number of pitchers to make today: ");
            int amountOfLemonade = int.Parse(Console.ReadLine());
            if (amountOfLemonade * 4 <= player.stand.inventory.lemons.Count() && amountOfLemonade * 4 <= player.stand.inventory.cupsOfSugar.Count() && amountOfLemonade * 50 <= player.stand.inventory.iceCubes.Count())
            {
                player.stand.MakeLemonade(amountOfLemonade);
            }
            else
            {
                Console.WriteLine("You don't have enough ingredients to make that much lemonade.");
                NeedSupplies();
            }
        }
    }
}
