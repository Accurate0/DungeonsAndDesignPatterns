namespace DnDesignPattern.Model
{
    /// <summary>
    /// Represents the shared attributes of
    /// an Item
    /// </summary>
    public abstract class Item
    {
        public virtual string Name {
            get => name;
            private set => name = value;
        }
        protected string name;
        public virtual MinMaxRandom Effect {
            get => effect;
            private set => effect = value;
        }
        protected MinMaxRandom effect;
        protected int cost;
        // Private backing field for property
        // To allow for a recursive property addition for the weapon cost
        // including enchantments
        public virtual int Cost {
            get => cost;
            set => cost = value;
        }

        public Item(string name, int cost, MinMaxRandom effect)
        {
            Name = name;
            Cost = cost;
            Effect = effect;
        }

        public override string ToString()
        {
            return $"Name     : {Name}\nCost     : {Cost}\nEffect   : {Effect}\n";
        }

        public virtual int Use()
        {
            return 0;
        }
    }
}
