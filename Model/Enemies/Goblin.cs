namespace DnDesignPattern.Model.Enemies
{
    public class Goblin : Enemy
    {
        public const string NAME = "Goblin";
        public const int MAX_HEALTH = 30;
        public const int MIN_DAMAGE = 3;
        public const int MAX_DAMAGE = 8;
        public const int MIN_DEFENCE = 4;
        public const int MAX_DEFENCE = 8;
        public const int GOLD_REWARD = 20;

        public Goblin(Ability ability)
            : base(NAME, MAX_HEALTH,
                    new MinMaxRandom(MIN_DAMAGE, MAX_DAMAGE),
                    new MinMaxRandom(MIN_DEFENCE, MAX_DEFENCE),
                    GOLD_REWARD, ability)
        {}

        // ASCII Art Reference: https://ascii.co.uk/art/goblin
        public override string ToString()
        {
            return
            "       ,      ,\n" +
            "      /(.-\"\"-.)\\\n" +
            "  |\\  \\/      \\/  /|\n" +
            "  | \\ / =.  .= \\ / |\n" +
            "  \\( \\   o\\/o   / )/\n" +
            "   \\_, '-/  \\-' ,_/\n" +
            "     /   \\__/   \\\n" +
            "     \\ \\__/\\__/ /\n" +
            "   ___\\ \\|--|/ /___\n" +
            " /`    \\      /    `\\\n" +
            "/       '----'       \\\n";
        }
    }
}
