using System.Collections.Generic;
using System.Linq;

using DnDesignPattern.Model;
using DnDesignPattern.Views;
using DnDesignPattern.Model.Items;

namespace DnDesignPattern.Controller.States
{
    /// <summary>
    /// A state to handle all the shop events
    /// Similar in some ways to the EnchantmentState
    /// </summary>
    public class ShopState : State
    {
        private ShopView view;
        public ShopState(GameEngine context, UserInterface ui, ShopView view) : base(context, ui)
        {
            this.view = view;
        }

        public override void Action()
        {
            view.Display(Context.Player.ToString());
            view.DisplayShopMenu();

            var input = UI.getInput("> ", 0, 2);
            switch(input) {
                case 0:
                    view.DisplayMenuReturn();
                    Context.Pop();
                    break;

                case 1:
                    BuyItem();
                    break;

                case 2:
                    SellItem();
                    break;
            }
        }

        private void BuyItem()
        {
            view.DisplayBuyMenu();

            var input = UI.getInput("> ", 0, 3);
            try {
                switch(input) {
                    case 0:
                        view.DisplayMessage("Returning to previous menu..");
                        break;

                    case 1:
                        input = SelectFromList<Weapon>(Context.Shop.Weapons, view);
                        purchaseItem<Weapon>(input, Context.Shop.Weapons, Context.Player.AddItem);
                        break;

                    case 2:
                        input = SelectFromList<Armour>(Context.Shop.Armours, view);
                        purchaseItem<Armour>(input, Context.Shop.Armours, Context.Player.AddItem);
                        break;

                    case 3:
                        input = SelectFromList<Potion>(Context.Shop.Potions, view);
                        purchaseItem<Potion>(input, Context.Shop.Potions, Context.Player.AddItem);
                        break;
                }
            } catch(PlayerInventoryException e) {
                view.DisplayError(e.Message);
            }

            if(input < 0) {
                view.DisplayMenuReturn();
            }
        }
        private delegate void AddItemMethod<T>(T item);

        /// <summary>
        /// Since it's basically impossible to have proper Item polymorphism.
        /// This function takes in an delegate (effectively function pointer)
        /// to the correct add function based on the type T, and then that
        /// delegate is called in order to put the item into the player's correct
        /// inventory, this basically just reduces code duplication by adding
        /// a little bit of complexity through delegates.
        /// </summary>
        /// <param name="input"></param> element of list to buy
        /// <param name="list"></param> list to buy from
        /// <param name="addItem"></param> how to add the item to the player correctly
        /// <typeparam name="T"></typeparam> refers to one of the Item subtypes
        private void purchaseItem<T>(int input, IEnumerable<T> list, AddItemMethod<T> addItem) where T : Item
        {
            if(input >= 0) {
                T item = list.ElementAt(input);
                if(Context.Player.Gold >= item.Cost) {
                    addItem(item);
                    Context.Player.Gold -= item.Cost;
                    view.DisplayMessage($"Bought {item.Name} for {item.Cost}");
                } else {
                    view.DisplayCannotAfford(item.Name, Context.Player.Gold, item.Cost);
                }
            }
        }

        private void SellItem()
        {
            if(Context.Player.ItemCount == 0) {
                view.DisplayWarning("You don't have any items! Can't sell what you don't have");
                return;
            }

            Item item = null;
            view.DisplaySellMenu();

            var input = UI.getInput("> ", 0, 3);
            switch(input) {
                case 0:
                    view.DisplayMessage("Returning to previous menu..");
                    break;

                case 1:
                    input = SelectFromList<Weapon>(Context.Player.Weapons, view);
                    if(input >= 0) {
                        item = Context.Player.RemoveWeapon(input);
                    }
                    break;

                case 2:
                    input = SelectFromList<Armour>(Context.Player.Armours, view);
                    if(input >= 0) {
                        item = Context.Player.RemoveArmour(input);
                    }
                    break;

                case 3:
                    input = SelectFromList<Potion>(Context.Player.Potions, view);
                    if(input >= 0) {
                        item = Context.Player.RemovePotion(input);
                    }
                    break;
            }

            if(input < 0) {
                view.DisplayMessage("Returning to previous menu..");
            } else {
                Context.Player.Gold += item.Cost / 2;
                view.DisplayMessage($"Sold {item.Name} for {item.Cost / 2}");
            }
        }

        public override string ToString()
        {
            return "Shop";
        }
    }
}
