using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using DnDesignPattern.Model.Items;

namespace DnDesignPattern.Model
{
    /// <summary>
    /// Represents the player and their inventory
    /// </summary>
    public class Player : Unit
    {
        public static readonly int MAX_INVENTORY = 15;
        public static readonly int MAX_HEALTH = 30;
        public static readonly int STARTING_GOLD = 100;

        private List<Weapon> weapons { get; }
        private List<Armour> armours { get; }
        private List<Potion> potions { get; }

        public ReadOnlyCollection<Weapon> Weapons { get => weapons.AsReadOnly(); }
        public ReadOnlyCollection<Armour> Armours { get => armours.AsReadOnly(); }
        public ReadOnlyCollection<Potion> Potions { get => potions.AsReadOnly(); }

        public int ItemCount { get; private set; }
        public Weapon CurrentWeapon { get; set; }
        public Armour CurrentArmour { get; set; }
        public int Gold { get; set; }

        public Player() : base("Player", MAX_HEALTH)
        {
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            potions = new List<Potion>();
            CurrentArmour = null;
            CurrentWeapon = null;
            Gold = STARTING_GOLD;
            ItemCount = 0;
        }

        public Player(string name) : base(name, MAX_HEALTH)
        {
            weapons = new List<Weapon>();
            armours = new List<Armour>();
            potions = new List<Potion>();
            CurrentArmour = null;
            CurrentWeapon = null;
            Gold = STARTING_GOLD;
            ItemCount = 0;
        }

        public void AddItem(Weapon w)
        {
            if(ItemCount == MAX_INVENTORY) {
                throw new PlayerInventoryException("You don't have any space remaining");
            }

            weapons.Add(w);
            ItemCount++;
        }

        public void AddItem(Armour a)
        {
            if(ItemCount == MAX_INVENTORY) {
                throw new PlayerInventoryException("You don't have any space remaining");
            }

            armours.Add(a);
            ItemCount++;
        }

        public void AddItem(Potion p)
        {
            if(ItemCount == MAX_INVENTORY) {
                throw new PlayerInventoryException("You don't have any space remaining");
            }

            potions.Add(p);
            ItemCount++;
        }

        public Weapon RemoveWeapon(int i)
        {
            var weapon = Weapons.ElementAt(i);
            weapons.RemoveAt(i);
            ItemCount--;

            return weapon;
        }
        public Armour RemoveArmour(int i)
        {
            var armour = Armours.ElementAt(i);
            armours.RemoveAt(i);
            ItemCount--;

            return armour;
        }

        public Potion RemovePotion(int i)
        {
            var potion = Potions.ElementAt(i);
            potions.RemoveAt(i);
            ItemCount--;

            return potion;
        }

        public override Attack Attack() => new Attack("Regular Attack", CurrentWeapon.Use());
        public override int Defend(int damage, bool ignoreArmour)
        {
            var def = CurrentArmour.Effect.Value;
            if(ignoreArmour) {
                Health -= damage;
            } else {
                Health -= Math.Max(0, damage - def);
            }

            return def;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Name    : {Name}\n");
            sb.Append($"Health  : {Health}\n");
            sb.Append($"Gold    : {Gold}\n");
            sb.Append($"Weapon  : {CurrentWeapon.Name}\n");
            sb.Append($"Armour  : {CurrentArmour.Name}\n");

            return sb.ToString();
        }

        public string InventoryToString()
        {
            var sb = new StringBuilder();

            if(Weapons.Count > 0) {
                sb.Append("Weapons: \n");
                sb.Append(
                            Weapons.Select(x => $"\n{x.ToString()}")
                                .Aggregate((x, y) => $"{x}\n{y}")
                );
                sb.Append("\n");
            } else {
                sb.Append("You have no weapons!\n");
            }

            if(Armours.Count > 0) {
                sb.Append("Armours: \n");
                sb.Append(
                            Armours.Select(x => $"\n{x.ToString()}")
                                .Aggregate((x, y) => $"{x}\n{y}")
                );
                sb.Append("\n");
            } else {
                sb.Append("You have no armours!\n");
            }

            if(Potions.Count > 0) {
                sb.Append("Potions: \n");
                sb.Append(
                            Potions.Select(x => $"\n{x.ToString()}")
                                .Aggregate((x, y) => $"{x}\n{y}")
                );
                sb.Append("\n");
            } else {
                sb.Append("You have no potions!\n");
            }


            return sb.ToString();
        }
    }
}
