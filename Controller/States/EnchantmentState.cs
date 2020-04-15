using DnDesignPattern.Views;
using DnDesignPattern.Model;
using DnDesignPattern.Model.Items;
using DnDesignPattern.Model.Items.Enchantments;

namespace DnDesignPattern.Controller.States
{
    /// <summary>
    /// State used to control all enchantment of inventory
    /// or equipped Weapons
    /// </summary>
    public class EnchantmentState : State
    {
        private EnchantmentView view;
        public EnchantmentState(GameEngine context, UserInterface ui, EnchantmentView view) : base(context, ui)
        {
            this.view = view;
        }

        /// <summary>
        /// Returns an enchanted weapon according to the menu
        /// </summary>
        /// <param name="i"></param> Which enchantment, based on menu options
        /// <param name="w"></param> Weapon to enchant
        /// <returns>Enchanted Weapon</returns>
        private Weapon enchantWeapon(int i, Weapon w)
        {
            switch(i)
            {
                case 1:
                    return new Damage(w, "Damage +2", 5, new MinMaxRandom(2, 2));

                case 2:
                    return new Damage(w, "Damage +5", 10, new MinMaxRandom(5, 5));

                case 3:
                    return new FireDamage(w, "Fire Damage", 20, new MinMaxRandom(5, 10));

                case 4:
                    return new DamageMultiplier(w, "Power-Up", 10, new MinMaxRandom(11, 11));
            }

            return null;
        }

        /// <summary>
        /// Using the enchantWeapon function, we enchant
        /// a user chosen weapon from the inventory, and we
        /// remove the old weapon and readd the enchanted weapon
        /// </summary>
        /// <param name="enchantmentType"></param>
        private void enchantInventory(int enchantmentType)
        {
            if(Context.Player.Weapons.Count == 0) {
                view.DisplayWarning("No Enchantable Items in Inventory");
            } else {
                int input = SelectFromList<Weapon>(Context.Player.Weapons, view);

                var weaponToEnchant = Context.Player.RemoveWeapon(input - 1);

                view.DisplayEnchanting(weaponToEnchant.Name);

                var enchantedWeapon = enchantWeapon(enchantmentType, weaponToEnchant);
                var cost = enchantedWeapon.Cost - weaponToEnchant.Cost;
                if(Context.Player.Gold >= cost) {
                    Context.Player.Gold -= cost;
                    Context.Player.AddItem(enchantedWeapon);
                    view.DisplayNewWeapon(enchantedWeapon.Name);
                } else {
                    view.DisplayCannotAfford(enchantedWeapon.Name, Context.Player.Gold, cost);
                }
            }
        }

        /// <summary>
        /// Similar as above, enchants the current equipped item
        /// and reequips it
        /// </summary>
        /// <param name="enchantmentType"></param>
        private void enchantEquipped(int enchantmentType)
        {
            var currentWeapon = Context.Player.CurrentWeapon;

            view.DisplayEnchanting(currentWeapon.Name);

            var enchantedWeapon = enchantWeapon(enchantmentType, currentWeapon);
            var cost = enchantedWeapon.Cost - currentWeapon.Cost;

            if(Context.Player.Gold >= cost) {
                Context.Player.Gold -= cost;
                Context.Player.CurrentWeapon = enchantedWeapon;
                view.DisplayNewWeapon(enchantedWeapon.Name);
            } else {
                view.DisplayCannotAfford(enchantedWeapon.Name, Context.Player.Gold, cost);
            }
        }

        /// <summary>
        /// Main Menu system for enchantments
        /// </summary>
        public override void Action()
        {
            int input;

            view.DisplayEnchantmentMenu();

            var enchantment = UI.getInput("> ", 0, 4);
            if(enchantment == 0) {
                view.DisplayMenuReturn();
                Context.Pop();
            } else {
                view.DisplayEnchantmentSubMenu();

                input = UI.getInput("> ", 1, 2);
                switch(input) {
                    case 1:
                        enchantInventory(enchantment);
                        break;

                    case 2:
                        enchantEquipped(enchantment);
                        break;
                }
            }
        }

        public override string ToString()
        {
            return "Enchant Weapons";
        }
    }
}
