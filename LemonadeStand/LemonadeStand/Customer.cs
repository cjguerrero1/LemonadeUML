using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        static Random random = new Random();
        List<Lemonade> cupOfLemonade = new List<Lemonade>();
        public int SetChanceToBuy(int forecast, int temperature)
        {
            int chance = random.Next(20,90);
            switch (forecast)
            {
                case 0:
                    chance -= 10;
                    break;
                case 1:
                    chance -= 5;
                    break;
                case 2:
                    chance += 2;
                    break;
                case 3:
                    chance += 5;
                    break;
            }
            switch (temperature)
            {
                case 0:
                    chance -= 10;
                    break;
                case 1:
                    chance -= 5;
                    break;
                case 2:
                    chance += 2;
                    break;
                case 3:
                    chance += 5;
                    break;
            }
            return chance;
        }

        public double SetMaxPrice(int forecast, int temperature)
        {
            double price = random.Next(5,80);
            switch (forecast)
            {
                case 0:
                    price -= 5;
                    break;
                case 1:
                    price -= 2;
                    break;
                case 2:
                    price += 2;
                    break;
                case 3:
                    price += 5;
                    break;
            }
            switch (temperature)
            {
                case 0:
                    price -= 5;
                    break;
                case 1:
                    price -= 2;
                    break;
                case 2:
                    price += 2;
                    break;
                case 3:
                    price += 5;
                    break;
            }
            return (price/100);
        }

        public void BuyLemonade(Player player, Day day)
        {
            double price = SetMaxPrice(day.todayForecast, day.todayTemp);
            int chance = SetChanceToBuy(day.todayForecast, day.todayTemp);
            if (price >= day.dailyPrice && chance > 50)
            {
                player.stand.Sell();
                player.stand.cashRegister.cash += day.dailyPrice;
                day.dailySales++;
                Lemonade lemonade = new Lemonade();
                cupOfLemonade.Add(lemonade);
            }
        }
    }
}
