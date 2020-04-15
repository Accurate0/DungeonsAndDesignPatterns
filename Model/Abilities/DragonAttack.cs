namespace DnDesignPattern.Model.Abilities
{
    public class DragonAttack : Ability
    {
        private DoubleDamage doubleDamage;
        private LifeSteal lifeSteal;
        public DragonAttack(DoubleDamage dd, LifeSteal ls) : base(0.0)
        {
            doubleDamage = dd;
            lifeSteal = ls;
        }

        public override Attack Use(Enemy user)
        {
            return Execute(user);
        }

        public override Attack Execute(Enemy user)
        {
            if(lifeSteal.Roll()) {
                return lifeSteal.Execute(user);
            }

            if(doubleDamage.Roll()) {
                return doubleDamage.Execute(user);
            }

            return new Attack("Regular Attack", user.Damage.Value);
        }

        public override string ToString()
        {
            return doubleDamage.ToString() + " \n\t  " + lifeSteal.ToString();
        }
    }
}
