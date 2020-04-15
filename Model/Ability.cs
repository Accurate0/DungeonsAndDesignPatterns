using System;

namespace DnDesignPattern.Model
{
    /// <summary>
    /// The Ability Super class representing all the abilities,
    /// means enemies can use their abilities without being aware of
    /// which specific subtype of Ability they are using
    /// </summary>
    public abstract class Ability
    {
        private double chance;
        protected double Chance {
            get => chance;
            set {
                // Ensure value is valid
                if(value <= 1.00 && value >= 0.00) {
                    chance = value;
                } else {
                    throw new ArgumentOutOfRangeException("Chance", "must be between 0.00 and 1.00");
                }
            }
        }
        protected static readonly Random random = new Random();

        public Ability(double chance)
        {
            Chance = chance;
        }

        public abstract Attack Use(Enemy user);
        public abstract Attack Execute(Enemy user);

        public bool Roll()
        {
            return random.NextDouble() <= Chance;
        }
    }
}
