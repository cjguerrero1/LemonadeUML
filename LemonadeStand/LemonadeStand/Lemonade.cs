using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemonade
    {
     public int cupsOfLemonade = 10; 
     public void CheckIfFull(Inventory inventory)
        { 
            if (cupsOfLemonade == 0)
            {
                inventory.pitchersOfLemonade.RemoveAt(0);
            }
        }
    }
}
