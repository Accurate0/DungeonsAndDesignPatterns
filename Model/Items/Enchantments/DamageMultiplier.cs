namespace DnDesignPattern.Model.Items.Enchantments
{
    public class DamageMultiplier : Enchantment
    {
        public DamageMultiplier(Weapon next, string name, int cost, MinMaxRandom effect)
                : base(next, name, cost, effect)
        {}

        public override int Use()
        {
            return (int)((double)next.Use() * ((double)effect.Value / 10));
        }
    }
}
