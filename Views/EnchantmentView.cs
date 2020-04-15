namespace DnDesignPattern.Views
{
    public class EnchantmentView : ShopView
    {
        public void DisplayEnchantmentMenu()
        {
            DisplayMenu();
            Display("1 | Damage +2");
            Display("2 | Damage +5");
            Display("3 | Fire Damage");
            Display("4 | Power-Up");
            Display("0 | Exit");
        }

        public void DisplayEnchantmentSubMenu()
        {
            DisplayMenu();
            Display("1 | Enchant Weapon from Inventory");
            Display("2 | Enchant Currently Equipped Weapon");
        }

        public void DisplayNewWeapon(string str)
        {
            DisplayMessage($"New Weapon Name: {str}");
        }

        public void DisplayEnchanting(string str)
        {
            DisplayMessage($"Enchanting: {str}...");
        }
    }
}
