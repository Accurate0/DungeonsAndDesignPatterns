using System;

using DnDesignPattern.Controller;
using DnDesignPattern.Controller.States;
using DnDesignPattern.Model;
using DnDesignPattern.Model.Items;
using DnDesignPattern.Model.Items.Enchantments;
using DnDesignPattern.Views;

namespace DnDesignPattern
{
    class DungeonsAndDesignPatterns
    {
        static void Main(string[] args)
        {
            var view = new View();
            try {
                if(args.Length >= 1) {
                    ShopLoader sl = new ShopFileLoader();
                    var player = new Player();
                    var ui =  new UserInterface(view);

                    try {
                        Shop shop = sl.load(args[0]);

                        var gm = new GameEngine(player, shop);
                        // Default and first state
                        gm.Push(new MenuState(gm, ui, view));

                        while(gm.Running) {
                            gm.Update();
                        }

                    } catch(ShopLoaderException e) {
                        view.DisplayError($"Error loading shop: {e.Message}");
                    }
                } else {
                    view.DisplayError("Must pass shop file as a command line argument");
                }
            } catch(Exception e) {
                view.DisplayError($"Unexpected Error: {e.Message}");
                // view.DisplayError(e.StackTrace);
            }
        }
    }
}
