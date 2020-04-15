namespace DnDesignPattern.Model
{
    /// <summary>
    /// Represents similarities between Enemies and Players
    /// Makes it possible to add other Units such as NPCs in the future
    /// </summary>
    public abstract class Unit
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }

        private int health;
        public int Health {
            get => health;
            set {
                if(value > MaxHealth) {
                    health = MaxHealth;
                } else if(value <= 0) {
                    IsAlive = false;
                    health = 0;
                } else {
                    health = value;
                }
            }
        }
        public int MaxHealth { get; }

        public Unit(string name, int maxHealth)
        {
            IsAlive = true;
            Name = name;
            MaxHealth = maxHealth;
            Health = MaxHealth;
        }

        public abstract Attack Attack();
        public abstract int Defend(int damage, bool ignoreArmour);

        public virtual int Defend(int damage)
        {
            return Defend(damage, false);
        }
    }
}
