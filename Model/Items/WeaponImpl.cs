using System;

namespace DnDesignPattern.Model.Items
{
    public class WeaponImpl : Weapon
    {
        public WeaponImpl(string name, int cost,
                MinMaxRandom effect, string type, string damageType)
                : base(name, cost, effect, type, damageType)
        {}

        public override int Use()
        {
            return Effect.Value;
        }

        /// <summary>
        /// Construct a weapon object from csv
        /// </summary>
        /// <param name="csv"></param>
        /// <returns></returns>
        public static WeaponImpl FromCSV(string[] csv)
        {
            try {
                var name = csv[0].Trim();
                var minDamage = Convert.ToInt32(csv[1]);
                var maxDamage = Convert.ToInt32(csv[2]);
                var cost = Convert.ToInt32(csv[3]);
                var damageType = csv[4].Trim();
                var weaponType = csv[5].Trim();

                if(minDamage > maxDamage || minDamage < 0 ||  maxDamage < 0) {
                    throw new InvalidItemException($"Invalid weapon: {string.Join(" ", csv)}");
                }

                return new WeaponImpl(name, cost,
                        new MinMaxRandom(minDamage, maxDamage), weaponType, damageType);
            } catch(IndexOutOfRangeException e) {
                throw new InvalidItemException($"Invalid weapon: {string.Join(" ", csv)}", e);
            } catch(FormatException e) {
                throw new InvalidItemException($"Invalid weapon: {string.Join(" ", csv)}", e);
            }
        }
    }
}
