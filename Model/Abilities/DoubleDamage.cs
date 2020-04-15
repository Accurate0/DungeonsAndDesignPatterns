namespace DnDesignPattern.Model.Abilities
{
    public class DoubleDamage : Ability
    {
        public DoubleDamage(double chance) : base(chance)
        {}

        public override Attack Use(Enemy user)
        {
            if(Roll()) {
                return Execute(user);
            } else {
                return new Attack("Regular Attack", user.Damage.Value);
            }
        }

        public override Attack Execute(Enemy user)
        {
            return new Attack("Double Damage", user.Damage.Value * 2);
        }

        public override string ToString()
        {
            return $"Attacks do double damage {Chance * 100.0}% of the time";
        }
    }
}
