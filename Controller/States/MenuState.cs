using System.Linq;
using System.Collections.Generic;

using DnDesignPattern.Views;

namespace DnDesignPattern.Controller.States
{
    /// <summary>
    /// Contains a map which is a key value pair of
    /// integers to states, so when the user chooses a menu option,
    /// they simply pick a state that the menu will switch into
    /// </summary>
    public class MenuState : State
    {
        private View view;
        private Dictionary<int, State> options;
        public MenuState(GameEngine context, UserInterface ui, View view) : base(context, ui)
        {
            this.view = view;
            options = new Dictionary<int, State>();

            // State to int, representing a menu system
            options.Add(1, new ShopState(Context, UI, new ShopView()));
            options.Add(2, new EnchantmentState(Context, UI, new EnchantmentView()));
            options.Add(3, new EditPlayerState(Context, UI, new EditPlayerView()));
            options.Add(4, new BattleState(Context, UI, new BattleView(), new EnemyFactory()));
        }

        public override void Action()
        {
            var str = options
                        .Select(x => $"{x.Key} | {x.Value}")
                        .Append("0 | Exit")
                        .Aggregate((x, y) => $"{x}\n{y}");

            view.Display(Context.Player.ToString());
            view.DisplayMenu(str);

            var input = UI.getInput("> ", 0, options.Count);
            if(input == 0) {
                view.DisplayMessage("Thanks for playing!");
                Context.Pop();
            } else {
                Context.Push(options[input]);
            }
        }
    }
}
