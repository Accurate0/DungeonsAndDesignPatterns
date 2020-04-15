namespace DnDesignPattern.Model
{
    /// <summary>
    /// Simple class to encapsulate the description of an
    /// Attack and the damage done by the attack.
    /// </summary>
    public class Attack
    {
        public string Description { get; }
        public int Damage { get; }

        public Attack(string description, int damage)
        {
            Description = description;
            Damage = damage;
        }
    }
}
