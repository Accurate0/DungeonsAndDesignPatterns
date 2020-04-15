namespace DnDesignPattern.Model.Abilities
{
    public class NoDamage : Ability
    {
        public NoDamage(double chance) : base(chance)
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
            return new Attack("No Damage", 0);
        }

        public override string ToString()
        {
            return $"Attacks do no damage {Chance * 100.0}% of the time";
        }
    }
}
