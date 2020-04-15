namespace DnDesignPattern.Model.Items
{
    public abstract class Enchantment : Weapon
    {
        protected Weapon next;
        /// <summary>
        /// Returns the name of the Enchanted weapon
        /// with the enchantments listed as (Enchantment)
        /// </summary>
        /// <value></value>
        public override string Name {
            get {
                if(next == null) {
                    return name;
                } else {
                    return $"{next.Name} ({name})";
                }
            }
        }

        // If it's an Enchantment, find the effect of the original item
        // Enchantments have their own effects in the protected effect field
        public override MinMaxRandom Effect {
            get => next.Effect;
        }

        public override int Cost {
            get => cost + next.Cost;
            set => cost = value;
        }

        public Enchantment(Weapon next, string name, int cost, MinMaxRandom effect)
                : base(name, cost, effect, next.Type, next.DamageType)
        {
            this.next = next;
        }
    }
}
