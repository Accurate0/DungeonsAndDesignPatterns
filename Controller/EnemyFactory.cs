using System;

using DnDesignPattern.Model.Enemies;
using DnDesignPattern.Model;
using DnDesignPattern.Model.Abilities;

namespace DnDesignPattern.Controller
{
    // TODO: FIX HARDCODED VALUES
    public class EnemyFactory
    {
        public bool IsDragon { get; private set; }
        private static Enemy testEnemy = null;
        private static readonly Random random = new Random();
        private int SlimeProbability;
        private int GoblinProbability;
        private int OgreProbability;
        private int DragonProbability;

        public EnemyFactory()
        {
            SlimeProbability = 50;
            GoblinProbability = 30;
            OgreProbability = 20;
            DragonProbability = 0;
            IsDragon = false;
        }

        /// <summary>
        /// Uses the current state of the probabilities to create
        /// enemies with abilities according to the specification
        /// The probabilities are done via a number line sort of system
        /// from 0 to 100, for example at default probabilities, 0-50 random
        /// numbers are Slimes, 51 - 80 are Goblin, and 81-100 are Ogres,
        /// this probability scale shifts as the dragon's probability goes up
        /// and the others go down, this makes it certain that an enemy is chosen every
        /// time randomly, rather than assigning each a chance and then
        /// doing it over and over again until you get an enemy.
        /// </summary>
        /// <returns></returns>
        public Enemy MakeEnemy()
        {
            if(testEnemy != null) {
                return testEnemy;
            }

            var val = random.Next(1, 101);

            if(val <= SlimeProbability) {
                refreshProbabilities();
                return new Slime(new NoDamage(0.20));
            }

            if(val > SlimeProbability && val <= (SlimeProbability + GoblinProbability)) {
                refreshProbabilities();
                return new Goblin(new ExtraDamage(0.50, 3));
            }

            if(val > (SlimeProbability + GoblinProbability)
                    && val <= (SlimeProbability + GoblinProbability + OgreProbability)) {
                refreshProbabilities();
                return new Ogre(new DoubleAttack(0.20));
            }

            if(val > (SlimeProbability + GoblinProbability + OgreProbability)
                    && val <= (SlimeProbability + GoblinProbability
                                + OgreProbability + DragonProbability)) {
                refreshProbabilities();
                // We made a dragon, allow other controllers to check this to figure out
                // if we've reached a end game situtation
                IsDragon = true;
                return new Dragon(new DragonAttack(new DoubleDamage(0.25), new LifeSteal(0.1, 10)));
            }

            return null;
        }

        /// <summary>
        /// Refreshes the probabilities after each enemy is
        /// created, decreasing all enemies that can be by 5 and increasing
        /// the dragon by the sum of all possible decreases
        /// </summary>
        private void refreshProbabilities()
        {
            var total = 0;
            if(SlimeProbability - 5 >= 5) {
                total += 5;
                SlimeProbability -= 5;
            }

            if(GoblinProbability - 5 >= 5) {
                total += 5;
                GoblinProbability -= 5;
            }

            if(OgreProbability - 5 >= 5) {
                total += 5;
                OgreProbability -= 5;
            }

            DragonProbability += total;
        }

        /// <summary>
        /// Allows you to set a test enemy to force the
        /// factory to create a specific enemy and return that
        /// </summary>
        /// <param name="enemy"></param>
        public static void SetTestEnemy(Enemy enemy)
        {
            testEnemy = enemy;
        }
    }
}
