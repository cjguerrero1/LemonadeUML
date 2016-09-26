using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        public List<Lemon> lemons = new List<Lemon>();
        public List<Sugar> cupsOfSugar = new List<Sugar>();
        public List<Ice> iceCubes = new List<Ice>();
        public List<Lemonade> pitchersOfLemonade = new List<Lemonade>();
        public List<Cup> cups = new List<Cup>();

        public void DisplayInventory()
        {
            Console.WriteLine("Current Stock:");
            Console.WriteLine(lemons.Count + " lemon(s)");
            Console.WriteLine(iceCubes.Count + " ice cube(s)");
            Console.WriteLine(cupsOfSugar.Count + " cup(s) of sugar");
            Console.WriteLine(cups.Count + " cup(s)");
            Console.WriteLine(pitchersOfLemonade.Count + " pitcher(s) of lemonade");
        }

        public bool CanKeepSelling()
        {
            if (pitchersOfLemonade.Count == 0)
            {
                return false;
            }
            else if (cups.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public void ResetInventory()
        {
            lemons.Clear();
            cups.Clear();
            pitchersOfLemonade.Clear();
            cupsOfSugar.Clear();
            iceCubes.Clear();
        }

        public void Melt()
        {
            if (iceCubes.Count != 0)
            {
                Console.WriteLine("Your remaining ice melted.");
                iceCubes.Clear();
            }         
        }

        public void DumpOldLemonade()
        {
            if (pitchersOfLemonade.Count != 0)
            {
                Console.WriteLine("You dump your remaining lemonade.");
                pitchersOfLemonade.Clear();
            }
        }
    }
}
