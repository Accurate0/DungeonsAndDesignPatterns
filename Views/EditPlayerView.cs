namespace DnDesignPattern.Views
{
    public class EditPlayerView :  View
    {
        public void DisplayEquip(string newItem, string oldItem)
        {
            DisplayMessage($"Equipped {newItem}, replacing {oldItem}");
        }

        public void DisplayEditMenu()
        {
            DisplayMenu();
            Display("1 | Show Current Player");
            Display("2 | Edit Player Name");
            Display("3 | Edit Equipped Weapon");
            Display("4 | Edit Equipped Armour");
            Display("0 | Exit");
        }

        public void DisplayNameSet(string name)
        {
            DisplayMessage($"Name set to: {name}");
        }
    }
}
