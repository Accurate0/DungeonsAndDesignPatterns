using System;

namespace DnDesignPattern.Model
{
    /// <summary>
    /// Represents an enemy, extends and shares some attributes
    /// with the Player, which is why the Unit class exists
    /// </summary>
    public abstract class Enemy : Unit
    {
        public MinMaxRandom Damage { get; set; }
        public MinMaxRandom Defence { get; set; }
        public int GoldReward { get; }
        public Ability Ability { get; private set; }

        public Enemy(string name, int maxHealth,
                    MinMaxRandom damage, MinMaxRandom defence,
                    int goldReward, Ability ability) : base(name, maxHealth)
        {
            Damage = damage;
            Defence = defence;
            GoldReward = goldReward;
            Ability = ability;
        }

        public override Attack Attack()
        {
            return Ability.Use(this);
        }

        /// <summary>
        /// Reduces the player's health according to the spec
        /// with the ability to do damage that ignores armour
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="ignoreArmour"></param>
        /// <returns></returns>
        public override int Defend(int damage, bool ignoreArmour)
        {
            var def = Defence.Value;
            if(ignoreArmour) {
                Health -= damage;
            } else {
                Health -= Math.Max(0, damage - def);
            }

            return def;
        }
    }
}
