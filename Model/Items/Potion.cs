using System;

namespace DnDesignPattern.Model.Items
{
    public class Potion : Item
    {
        public enum PotionType
        {
            HEALING,
            HARMING
        }

        public PotionType Type { get; }

        public Potion(string name, int cost, MinMaxRandom effect, PotionType type) : base(name, cost, effect)
        {
            Type = type;
        }

        public override string ToString()
        {
            return  base.ToString() + $"Type     : {Type}\n";
        }

        public override int Use()
        {
            var dmgOrHeal = Effect.Value;
            if(Type == PotionType.HARMING) {
                return dmgOrHeal;
            } else {
                return -dmgOrHeal;
            }
        }

        /// <summary>
        /// Constructs a Potion object from csv
        /// </summary>
        /// <param name="csv"></param>
        /// <returns></returns>
        public static Potion FromCSV(string[] csv)
        {
            try {
                var name = csv[0].Trim();
                var minEffect = Convert.ToInt32(csv[1]);
                var maxEffect = Convert.ToInt32(csv[2]);
                var cost = Convert.ToInt32(csv[3]);
                var stringType = csv[4].Trim();

                PotionType type;
                if(stringType.Equals("H")) {
                    type = PotionType.HEALING;
                } else if (stringType.Equals("D")) {
                    type = PotionType.HARMING;
                } else {
                    throw new InvalidItemException($"expected H or D, got '{stringType}'");
                }

                if(minEffect > maxEffect || minEffect < 0 ||  maxEffect < 0) {
                    throw new InvalidItemException($"Invalid weapon: {string.Join(" ", csv)}");
                }

                return new Potion(name, cost, new MinMaxRandom(minEffect, maxEffect), type);
            } catch(IndexOutOfRangeException e) {
                throw new InvalidItemException($"Invalid potion: {string.Join(" ", csv)}", e);
            } catch(FormatException e) {
                throw new InvalidItemException($"Invalid potion: {string.Join(" ", csv)}", e);
            }
        }
    }
}
