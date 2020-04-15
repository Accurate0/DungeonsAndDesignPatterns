using System.Collections.Generic;
using System.Linq;

using DnDesignPattern.Model;
using DnDesignPattern.Views;

namespace DnDesignPattern.Controller
{
    /// <summary>
    /// Represents a State, with each state having access to
    /// the current Context of the GameEngine, and the UserInterface
    /// used to get input data from the user
    /// </summary>
    public abstract class State
    {
        protected GameEngine Context { get; }
        protected UserInterface UI { get; }
        public State(GameEngine context, UserInterface ui)
        {
            Context = context;
            UI = ui;
        }

        /// <summary>
        /// Represents the main action conducted by the state,
        /// must be overridden by a child class to define their own action
        /// </summary>
        public abstract void Action();

        /// <summary>
        /// Generic method to select from any given list of type T.
        /// Constructs and displays a single menu system, and uses
        /// the user interface to get the user to pick one.
        /// </summary>
        /// <param name="list"></param> List to choose from
        /// <param name="view"></param> View to display to
        /// <typeparam name="T"></typeparam> Must be an Item
        /// <returns>0 indexed position of the item selected</returns>
        protected int SelectFromList<T>(IEnumerable<T> list, View view) where T : Item
        {
            if(list.Count() == 0) {
                view.DisplayWarning("You don't have any items of this type!");
                return -1;
            }

            int i = 0;
            var str = list.Select(x => $"Item {++i}\n---\n{x}")
                          .Append("0 | Exit\n")
                          .Aggregate((x, y) => $"{x}\n{y}");

            view.DisplayMenu(str);

            var input = UI.getInput("Item Number > ", 0, list.Count());

            return input - 1;
        }
    }
}
