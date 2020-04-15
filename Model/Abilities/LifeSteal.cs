namespace DnDesignPattern.Model.Abilities
{
    public class LifeSteal : Ability
    {
        public int Heal { get; }
        public LifeSteal(double chance, int heal) : base(chance)
        {
            Heal = heal;
        }

        public override Attack Use(Enemy user)
        {
            if(Roll()) {
                return Execute(user);
            }

            // always do damage, only life steal sometimes
            return new Attack("Regular Attack", user.Damage.Value);
        }

        public override Attack Execute(Enemy user)
        {
            user.Health += Heal;
            return new Attack($"Lifesteal, healing for {Heal}", user.Damage.Value);
        }

        public override string ToString()
        {
            return $"Attacks can heal for {Heal} {Chance * 100.0}% of the time";
        }
    }
}
