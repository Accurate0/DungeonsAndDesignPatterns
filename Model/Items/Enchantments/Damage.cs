namespace DnDesignPattern.Model.Items.Enchantments
{
    public class Damage : Enchantment
    {
        public Damage(Weapon next, string name, int cost, MinMaxRandom effect)
                : base(next, name, cost, effect)
        {}

        public override int Use()
        {
            return next.Use() + effect.Value;
        }
    }
}
