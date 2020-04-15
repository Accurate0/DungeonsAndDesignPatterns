using System;

namespace DnDesignPattern.Views
{
    public class BattleView : View
    {
        public void DisplayEnemyStats(int health, string damage, string defence, int goldReward, string ability)
        {
            Console.WriteLine($"Health  : {health}\n" +
                              $"Damage  : {damage}\n" +
                              $"Defence : {defence}\n" +
                              $"Reward  : {goldReward} Gold\n" +
                              $"Ability : {ability}\n");
        }

        public void DisplayAttack(string attacker, string attackee, string attackType, int damage)
        {
            Console.WriteLine($"{attacker} used {attackType} dealing {damage} damage");
        }

        public void DisplayDefence(string attackee, int defence, int hpDiff, double percentageLost)
        {
            string blue = "\u001b[36m";
            string reset = "\u001b[00m";
            string red = "\u001b[31m";

            if(percentageLost >= 50.0) {
                Console.WriteLine($"{blue}It's super effective!{reset}");
            }

            Console.Write($"{attackee} blocks {defence} of the damage and loses {hpDiff} health ");
            if(percentageLost >= 50.0) {
                Console.Write($"{red}");
            }

            Console.WriteLine($"({(int)percentageLost}%){reset}\n");
        }

        public void DisplayHealth(string p1, string p2, int h1, int h2)
        {
            Console.WriteLine($"{p1} has {h1} health remaining!");
            Console.WriteLine($"{p2} has {h2} health remaining!\n");
        }

        public void DisplayHealth(string p1, int h1)
        {
            Console.WriteLine($"{p1} has {h1} health remaining!\n");
        }
        public void DisplayHeal(string player, int healing, int newHealth)
        {
            Console.WriteLine($"\n{player} healed for {healing}, current health: {newHealth}");
        }

        public void DisplayEnemyApproach(string name)
        {
            DisplayMessage($"{name} approaches..");
        }

        public void DisplayRound(int round)
        {
            DisplayMessage($"Round {round}");
        }

        public void DisplayEnemySlain(string name, int goldReward, int gold, int heal, int health)
        {
            DisplayMessageNoNewline(
                $"You have slain {name}\n" +
                $"\t  Gold: {goldReward} gold (Total: {gold})\n" +
                $"\t  Heal: {heal} HP   (Total: {health})\n"
            );
        }

        public void DisplayAttackMenu()
        {
            DisplayMenu();
            Display("1 | Attack with Current Weapon");
            Display("2 | Use Potion");
        }
    }
}
