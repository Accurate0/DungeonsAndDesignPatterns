namespace DnDesignPattern.Model.Items
{
    public abstract class Weapon : Item
    {
        public string Type { get; }
        public string DamageType { get; }
        public Weapon(string name, int cost, MinMaxRandom effect, string type, string damageType) : base(name, cost, effect)
        {
            Type = type;
            DamageType = damageType;
        }
        public override abstract int Use();

        public override string ToString()
        {
            return base.ToString() + $"Type     : {Type}\nDamage   : {DamageType}\n";
        }
    }
}
