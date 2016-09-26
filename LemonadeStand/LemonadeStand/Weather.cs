using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        static Random random = new Random();
        string[] temperatures = new string[] { "50 Degrees", "62 Degrees", "78 Degrees", "93 Degrees" };
        string[] forecasts = new string[] { "Rainy", "Cloudy", "Humid", "Sunny" };

        public int Temperature()
        {
            return random.Next(0, 4);
        }

        public void PrintTemperature(int temperature)
        {
            switch (temperature)
            {
                case 0:
                    Console.Write(temperatures[0]);
                    break;
                case 1:
                    Console.Write(temperatures[1]);
                    break;
                case 2:
                    Console.Write(temperatures[2]);
                    break;
                case 3:
                    Console.Write(temperatures[3]);
                    break;
            }
        }

        public int Forecast()
        {
            return random.Next(0, 4);
        }

        public void PrintForecast(int forecast)
        {
            switch (forecast)
            {
                case 0:
                    Console.WriteLine(", and " + forecasts[0]);
                    break;
                case 1:
                    Console.WriteLine(", and " + forecasts[1]);
                    break;
                case 2:
                    Console.WriteLine(", and " + forecasts[2]);
                    break;
                case 3:
                    Console.WriteLine(", and " + forecasts[3]);
                    break;
            }
        }
    }
}
