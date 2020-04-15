using System.Linq;
using System.Collections.Generic;

using DnDesignPattern.Model;

namespace DnDesignPattern.Controller
{
    /// <summary>
    /// The "GameEngine" or the state manager, simply keeps
    /// track of the current state, and the context of the operation by
    /// holding a long term relationship with two important model classes,
    /// the Player and the Shop, the current state is tracked via the use of
    /// a stack of states, making it easy to go back to the calling state
    /// by poping the current state off the stack
    /// </summary>
    public class GameEngine
    {
        private Stack<State> states;
        public Player Player { get; }
        public Shop Shop { get; }
        public bool Running { get; set; }

        public GameEngine(Player player, Shop shop)
        {
            states = new Stack<State>();
            Running = true;
            Player = player;
            Shop = shop;

            // Setup the player's initial items
            Player.CurrentWeapon = shop.Weapons
                                            .OrderBy(x => x.Cost)
                                            .First();
            Player.CurrentArmour = shop.Armours
                                            .OrderBy(x => x.Cost)
                                            .First();
        }

        /// <summary>
        /// Runs the current states action, else
        /// marks it as the end of the Engine
        /// </summary>
        public void Update()
        {
            if(states.Count != 0) {
                states.Peek().Action();
            } else {
                Running = false;
            }
        }

        /// <summary>
        /// Clears all current states
        /// </summary>
        public void Clear()
        {
            states.Clear();
        }

        /// <summary>
        /// Pushes a new state
        /// </summary>
        /// <param name="state"></param>
        public void Push(State state)
        {
            states.Push(state);
        }

        /// <summary>
        /// Pops off the current state
        /// </summary>
        public void Pop()
        {
            states.Pop();
        }
    }
}
