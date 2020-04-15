using DnDesignPattern.Model.Items;
using DnDesignPattern.Views;

namespace DnDesignPattern.Controller.States
{
    /// <summary>
    /// State/Controller used to edit the player.
    /// Changing things like the currently equipped item
    /// or the name, even just showing information about the
    /// current player
    /// </summary>
    public class EditPlayerState : State
    {
        public EditPlayerView view;
        public EditPlayerState(GameEngine context, UserInterface ui, EditPlayerView view) : base(context, ui)
        {
            this.view = view;
        }

        /// <summary>
        /// Main menu for editting the Player,
        /// allows the user to also print the current player information
        /// </summary>
        public override void Action()
        {
            view.DisplayEditMenu();

            var input = UI.getInput("> ", 0, 4);
            view.Display(Context.Player.ToString());

            switch(input) {
                case 0:
                    view.DisplayMenuReturn();
                    Context.Pop();
                    break;

                case 1:
                    view.Display(Context.Player.InventoryToString());
                    break;

                case 2:
                    var str = UI.getInput("Enter Name: ");
                    Context.Player.Name = str;
                    view.DisplayNameSet(Context.Player.Name);
                    break;

                case 3:
                    equipWeapon();
                    break;

                case 4:
                    equipArmour();
                    break;

            }
        }

        /// <summary>
        /// Prompts the user to select a weapon from the inventory to equip
        /// from, and then replaces the weapon slot and removes the equipped
        /// item from the inventory
        /// </summary>
        private void equipWeapon()
        {
            int input = SelectFromList<Weapon>(Context.Player.Weapons, view);
            if(input >= 0) {
                var newWeapon = Context.Player.RemoveWeapon(input);
                var oldWeapon = Context.Player.CurrentWeapon;

                Context.Player.AddItem(oldWeapon);
                Context.Player.CurrentWeapon = newWeapon;
                view.DisplayEquip(newWeapon.Name, oldWeapon.Name);
            } else {
                view.DisplayMenuReturn();
            }
        }

        /// <summary>
        /// Same as above but for armour
        /// </summary>
        private void equipArmour()
        {
            int input = SelectFromList<Armour>(Context.Player.Armours, view);
            if(input >= 0) {
                var newArmour = Context.Player.RemoveArmour(input);
                var oldArmour = Context.Player.CurrentArmour;

                Context.Player.AddItem(oldArmour);
                Context.Player.CurrentArmour = newArmour;
                view.DisplayEquip(newArmour.Name, oldArmour.Name);
            } else {
                view.DisplayMenuReturn();
            }
        }

        public override string ToString()
        {
            return "Edit Player";
        }
    }
}
