using System.IO;
using System.Linq;
using System.Collections.Generic;

using DnDesignPattern.Model;
using DnDesignPattern.Model.Items;

namespace DnDesignPattern.Controller
{
    public class ShopFileLoader : ShopLoader
    {
        /// <summary>
        /// Load the file and construct a Shop from
        /// the found items
        /// </summary>
        /// <param name="file">file to load</param>
        /// <returns></returns>
        public Shop load(string file)
        {
            var weapons = new List<Weapon>();
            var armours = new List<Armour>();
            var potions = new List<Potion>();

            try {
                File.ReadAllLines(file).ToList().ForEach(line => {
                    var s = line.Split(',');
                    var rest = s.Skip(1).ToArray();
                    switch(s[0]) {
                        case "W":
                            weapons.Add(WeaponImpl.FromCSV(rest));
                            break;

                        case "A":
                            armours.Add(Armour.FromCSV(rest));
                            break;

                        case "P":
                            potions.Add(Potion.FromCSV(rest));
                            break;
                        default:
                            throw new InvalidItemException("Invalid entry in file");
                    }
                });
            } catch(FileNotFoundException e) {
                throw new ShopLoaderException(e.Message, e);
            } catch(InvalidItemException e) {
                throw new ShopLoaderException(e.Message, e);
            }

            return new Shop(weapons, armours, potions);
        }
    }
}
