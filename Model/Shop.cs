using System.Collections.Generic;

using DnDesignPattern.Model.Items;

namespace DnDesignPattern.Model
{
    /// <summary>
    /// Represents a shop
    /// Since a shop doesn't have limits, it's possible to just expose
    /// the shop's classfields as properties
    /// </summary>
    public class Shop
    {
        public List<Weapon> Weapons { get; }
        public List<Armour> Armours { get; }
        public List<Potion> Potions { get; }

        public Shop(List<Weapon> weapons, List<Armour> armours, List<Potion> potions)
        {
            Weapons = weapons;
            Armours = armours;
            Potions = potions;
        }
    }
}
