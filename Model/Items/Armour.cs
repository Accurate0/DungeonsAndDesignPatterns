using System;

namespace DnDesignPattern.Model.Items
{
    public class Armour : Item
    {
        public string Material { get; }

        public Armour(string name, int cost, MinMaxRandom effect, string material) : base(name, cost, effect)
        {
            Material = material;
        }

        public override string ToString()
        {
            return base.ToString() + $"Material : {Material}\n";
        }

        /// <summary>
        /// Constructs an Armour object from a string array of csv
        /// </summary>
        /// <param name="csv"></param>
        /// <returns></returns>
        public static Armour FromCSV(string[] csv)
        {
            try {
                var name = csv[0].Trim();
                var minDefence = Convert.ToInt32(csv[1]);
                var maxDefence = Convert.ToInt32(csv[2]);
                var cost = Convert.ToInt32(csv[3]);
                var material = csv[4].Trim();

                if(minDefence > maxDefence || minDefence < 0 ||  maxDefence < 0) {
                    throw new InvalidItemException($"Invalid weapon: {string.Join(" ", csv)}");
                }

                return new Armour(name, cost, new MinMaxRandom(minDefence, maxDefence), material);
            } catch(IndexOutOfRangeException e) {
                throw new InvalidItemException($"Invalid armour: {string.Join(" ", csv)}", e);
            } catch(FormatException e) {
                throw new InvalidItemException($"Invalid armour: {string.Join(" ", csv)}", e);
            }
        }
    }
}
