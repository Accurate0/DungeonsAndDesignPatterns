using System;

namespace DnDesignPattern.Views
{
    public class ShopView : View
    {
        public void DisplayShop(string str)
        {
            Console.WriteLine("Shop Items");
            Console.WriteLine("----------");
            Console.WriteLine(str);
        }

        public void DisplayCannotAfford(string name, int have, int need)
        {
            DisplayWarning($"You can't afford {name}! (Need: {need}, Have: {have})");
        }

        public void DisplaySellMenu()
        {
            DisplayMenu();
            Display("1 | Sell Weapons");
            Display("2 | Sell Armour");
            Display("3 | Sell Potions");
            Display("0 | Exit");
        }

        public void DisplayBuyMenu()
        {
            DisplayMenu();
            Display("1 | Buy Weapons");
            Display("2 | Buy Armour");
            Display("3 | Buy Potions");
            Display("0 | Exit");
        }

        public void DisplayShopMenu()
        {
            DisplayMenu();
            Display("1 | Buy Item");
            Display("2 | Sell Item");
            Display("0 | Exit");
        }
    }
}
