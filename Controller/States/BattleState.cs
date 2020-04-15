using DnDesignPattern.Views;
using DnDesignPattern.Model;
using DnDesignPattern.Model.Items;

namespace DnDesignPattern.Controller.States
{
    /// <summary>
    /// This controller/state handles all of the battle.
    /// Contains the main gameplay logic, uses model classes and other controllers
    /// such as the EnemyFactory to create new enemies for the Player to battle.
    /// </summary>
    public class BattleState : State
    {
        private BattleView view;
        private EnemyFactory ef;
        public BattleState(GameEngine context, UserInterface ui,
                            BattleView view, EnemyFactory ef) : base(context, ui)
        {
            this.view = view;
            this.ef = ef;
        }

        /// <summary>
        /// Does some simple maths to figure out the percentage hp lost
        /// </summary>
        /// <param name="oldHP"></param>
        /// <param name="currentHP"></param>
        /// <param name="maxHealth"></param>
        /// <returns>Percentage HP lost</returns>
        private double calcPercentageHPLost(int oldHP, int currentHP, int maxHealth)
        {
            return ((double)(oldHP - currentHP)/(double)maxHealth) * 100.0;
        }

        /// <summary>
        /// Does the enemies turn if it is still alive, otherwise, displays
        /// the enemy as dead and gives the player their reward
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="player"></param>
        private void enemyTurn(Enemy enemy, Player player)
        {
            if(enemy.IsAlive) {
                var oldHP = player.Health;
                Attack enemyAttack = enemy.Attack();
                int defence = player.Defend(enemyAttack.Damage);
                double percentageLost = calcPercentageHPLost(oldHP, player.Health, player.MaxHealth);

                view.DisplayAttack(enemy.Name,
                    player.Name,
                    enemyAttack.Description,
                    enemyAttack.Damage);
                view.DisplayDefence(player.Name, defence, oldHP - player.Health, percentageLost);
                view.DisplayHealth(player.Name, enemy.Name, player.Health, enemy.Health);
            } else {
                var heal = (int)((double)player.Health * 1.5) - player.Health;
                player.Health += heal;
                player.Gold += enemy.GoldReward;
                view.DisplayEnemySlain(enemy.Name, enemy.GoldReward, player.Gold, heal, player.Health);
            }
        }

        /// <summary>
        /// Executes the player's turn, either attacking the enemy
        /// or using a potion
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <param name="input"></param>
        /// <returns>Whether the player actually completed their turn</returns>
        private bool playerTurn(Player player, Enemy enemy, int input)
        {
            bool playerTurnCompleted = false;

            if(input == 1) {
                Attack playerAttack = player.Attack();
                int oldHP = enemy.Health;
                int defence = enemy.Defend(playerAttack.Damage);
                double percentageLost = calcPercentageHPLost(oldHP, enemy.Health, enemy.MaxHealth);

                view.DisplayAttack(player.Name,
                                    enemy.Name,
                                    playerAttack.Description,
                                    playerAttack.Damage);
                view.DisplayDefence(enemy.Name, defence, oldHP - enemy.Health, percentageLost);
                playerTurnCompleted = true;
            } else {
                if(player.Potions.Count == 0) {
                    view.DisplayWarning("You don't have any potions!");
                } else {
                    input = SelectFromList<Potion>(player.Potions, view);
                    var potion = player.RemovePotion(input);

                    int effect = potion.Use();
                    // - is healing
                    // + is damage
                    if(effect < 0) {
                        player.Health += -effect;
                        view.DisplayHeal(player.Name, -effect, player.Health);
                    } else {
                        var oldHP = enemy.Health;
                        int defence = enemy.Defend(effect, true);
                        double percentageLost = calcPercentageHPLost(oldHP, enemy.Health, enemy.MaxHealth);

                        view.DisplayAttack(player.Name, enemy.Name, potion.Name, effect);
                        view.DisplayDefence(enemy.Name, defence, oldHP - enemy.Health, percentageLost);
                    }

                    playerTurnCompleted = true;
                }
            }

            return playerTurnCompleted;
        }

        /// <summary>
        /// Main battle loop, forces the player and enemy to battle without
        /// a retreat option.
        /// </summary>
        public override void Action()
        {
            // TODO: REMOVE THIS
            // EnemyFactory.SetTestEnemy(new Dragon(
            //     new DragonAttack(new DoubleDamage(0.25), new LifeSteal(0.1, 10))));

            bool playerTurnCompleted = false;
            int round = 1;
            Player player = Context.Player; // Convenience
            Enemy enemy = ef.MakeEnemy();

            view.Display(enemy.ToString());
            view.DisplayEnemyApproach(enemy.Name);
            view.DisplayEnemyStats(enemy.Health,
                                    enemy.Damage.ToString(),
                                    enemy.Defence.ToString(),
                                    enemy.GoldReward,
                                    enemy.Ability.ToString());

            view.Display("VS\n");
            view.Display(player.ToString());

            while(player.IsAlive && enemy.IsAlive) {
                playerTurnCompleted = false;

                view.DisplayRound(round);
                view.DisplayAttackMenu();

                var input = UI.getInput("> ", 1, 2);


                playerTurnCompleted = playerTurn(player, enemy, input);

                if(playerTurnCompleted) {
                    enemyTurn(enemy, player);
                    round++;
                }
            }

            if(!player.IsAlive) {
                Context.Clear();
                Context.Push(new GameOverState(Context, UI, new View(), false));
                return;
            }

            if(!enemy.IsAlive && ef.IsDragon) {
                Context.Clear();
                Context.Push(new GameOverState(Context, UI, new View(), true));
                return;
            }

            Context.Pop();
        }

        public override string ToString()
        {
            return "Battle";
        }
    }
}
