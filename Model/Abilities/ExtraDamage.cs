namespace DnDesignPattern.Model.Abilities
{
    public class ExtraDamage : Ability
    {
        public int BonusDamage { get; }
        public ExtraDamage(double chance, int bonusDamage) : base(chance)
        {
            BonusDamage = bonusDamage;
        }

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
            return new Attack($"+{BonusDamage} Bonus Damage Attack", user.Damage.Value + BonusDamage);
        }

        public override string ToString()
        {
            return $"Attacks deal +{BonusDamage} damage {Chance * 100.0}% of the time";
        }
    }
}
