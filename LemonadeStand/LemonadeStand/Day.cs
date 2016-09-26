using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        List<Customer> customers = new List<Customer>();
        static Random rnd = new Random();
        public int numberOfCustomers;
        public int todayTemp;
        public int todayForecast;
        public int dailySales;
        public double dailyPrice;
        Weather weather = new Weather();

        public Day()
        {
            this.dailySales = 0;
            this.todayForecast = weather.Forecast();
            this.todayTemp = weather.Temperature();
            weather.PrintTemperature(todayTemp);
            weather.PrintForecast(todayForecast);
            this.dailyPrice = SetPricePerGlass();
            this.numberOfCustomers = GetNumberOfCustomers();
            MakeCustomers();
        }

        public int GetNumberOfCustomers()
        {
            return rnd.Next(50, 101);
        }

        public void MakeCustomers()
        {  
            for (int loops = 0;  loops < numberOfCustomers; loops++)
            {
                Customer customer = new Customer();
                customers.Add(customer);
            }
        }

        public static double SetPricePerGlass()
        {
            Console.WriteLine("Please set the price per glass (0.00-1.00): ");
            double price = double.Parse(Console.ReadLine());
            return price;
        }

        public void CustomersPassStand(Player player, Day day)
        {
            foreach (Customer customer in customers)
            {
                if (player.stand.inventory.CanKeepSelling())
                {
                    customer.BuyLemonade(player, day);
                }
            }
        }

        public void EndDay()
        {
            double dailyProfit = dailyPrice * dailySales;
            string profit = String.Format("{0:C}", dailyProfit);
            Console.WriteLine("Today you had {0} sales out of {1} potential customers and made ${2}.", dailySales, numberOfCustomers, dailyProfit);
        }
    }
}
