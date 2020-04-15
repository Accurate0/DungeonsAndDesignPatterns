namespace DnDesignPattern.Model.Enemies
{
    public class Dragon : Enemy
    {
        public const string NAME = "Dragon";
        public const int MAX_HEALTH = 100;
        public const int MIN_DAMAGE = 15;
        public const int MAX_DAMAGE = 30;
        public const int MIN_DEFENCE = 15;
        public const int MAX_DEFENCE = 20;
        public const int GOLD_REWARD = 100;

        public Dragon(Ability ability)
            : base(NAME, MAX_HEALTH,
                    new MinMaxRandom(MIN_DAMAGE, MAX_DAMAGE),
                    new MinMaxRandom(MIN_DEFENCE, MAX_DEFENCE),
                    GOLD_REWARD, ability)
        {}

        // ASCII Art Reference: https://ascii.co.uk/art/dragon
        public override string ToString()
        {
            return
            "                                          _   __,----'~~~~~~~~~`-----.__\n" +
            "                                   .  .    `//====-              ____,-'~`\n" +
            "                   -.            \\_|// .   /||\\  `~~~~`---.___./\n" +
            "             ______-==.       _-~o  `\\/    |||  \\           _,'`\n" +
            "       __,--'   ,=='||\\=_    ;_,_,/ _-'|-   |`\\   \\        ,'\n" +
            "    _-'      ,='    | \\\\`.    '',/~7  /-   /  ||   `\\.     /\n" +
            "  .'       ,'       |  \\\\  \\_    /  /-   /   ||      \\   /\n" +
            " / _____  /         |     \\\\.`-_/  /|- _/   ,||       \\ /\n" +
            ",-'     `-|--'~~`--_ \\     `==-/  `| \'--===-'       _/`\n" +
            "          '         `-|      /|    )-'\\~'      _,--\"\'\n" +
            "                      '-~^\\_/ |    |   `\\_   ,^             /\\\n" +
            "                           /  \\     \\__   \\/~               `\\__\n" +
            "                       _,-' _/'\\ ,-'~____-'`-/                 ``===\\\n" +
            "                      ((->/'    \\|||' `.     `\\.  ,                _||\n" +
            "        ./                       \\_     `\\      `~---|__i__i__\\--~'_/\n" +
            "       <_n_                     __-^-_    `)  \\-.______________,-~'\n" +
            "        `B'\\)                  ///,-'~`__--^-  |-------~~~~^'\n" +
            "        /^>                           ///,--~`-\\\n" +
            "       `  `\n";
        }
    }
}
