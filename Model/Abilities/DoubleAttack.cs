namespace DnDesignPattern.Model.Abilities
{
    public class DoubleAttack : Ability
    {
        public DoubleAttack(double chance) : base(chance)
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
            return new Attack("Double Attack", user.Damage.Value + user.Damage.Value);
        }

        public override string ToString()
        {
            return $"Attacks twice {Chance * 100.0}% of the time";
        }
    }
}
