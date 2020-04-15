namespace DnDesignPattern.Model.Enemies
{
    public class Slime : Enemy
    {
        public const string NAME = "Slime";
        public const int MAX_HEALTH = 10;
        public const int MIN_DAMAGE = 3;
        public const int MAX_DAMAGE = 5;
        public const int MIN_DEFENCE = 0;
        public const int MAX_DEFENCE = 2;
        public const int GOLD_REWARD = 10;

        public Slime(Ability ability)
            : base(NAME, MAX_HEALTH,
                    new MinMaxRandom(MIN_DAMAGE, MAX_DAMAGE),
                    new MinMaxRandom(MIN_DEFENCE, MAX_DEFENCE),
                    GOLD_REWARD, ability)
        {}

        // ASCII Art Reference: https://textart.sh/topic/slime
        public override string ToString()
        {
            return
            "           ░░░░░░░░░░\n" +
            "       ░░░░        ░░░░░░\n" +
            "     ░░                  ░░\n" +
            "   ░░                    ░░░░\n" +
            " ░░                      ░░░░░░\n" +
            " ░░                        ░░░░\n" +
            "░░                ░░    ░░  ░░░░░░\n" +
            "░░                ██░░  ██    ░░░░\n" +
            "░░                ██░░  ██    ░░░░\n" +
            "░░            ░░            ░░░░░░\n" +
            "░░░░░░                      ░░░░░░\n" +
            " ░░░░░░                  ░░░░░░\n" +
            " ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
            "     ░░░░░░░░░░░░░░░░░░░░░░\n";
        }
    }
}
