namespace DnDesignPattern.Model.Enemies
{
    public class Ogre : Enemy
    {
        public const string NAME = "Ogre";
        public const int MAX_HEALTH = 40;
        public const int MIN_DAMAGE = 5;
        public const int MAX_DAMAGE = 10;
        public const int MIN_DEFENCE = 6;
        public const int MAX_DEFENCE = 12;
        public const int GOLD_REWARD = 40;

        public Ogre(Ability ability)
            : base(NAME, MAX_HEALTH,
                    new MinMaxRandom(MIN_DAMAGE, MAX_DAMAGE),
                    new MinMaxRandom(MIN_DEFENCE, MAX_DEFENCE),
                    GOLD_REWARD, ability)
        {}

        // ASCII Art Reference: https://ascii.co.uk/art/ogre
        public override string ToString()
        {
            return
            "         __,='`````'=/__\n" +
            "        '//  (o) \\(o) \\ `'         _,-,\n" +
            "        //|     ,_)   (`\\      ,-'`_,-\\\n" +
            "      ,-~~~\\  `'==='  /-,      \\==```` \\__\n" +
            "     /        `----'     `\\     \\       \\/\n" +
            "  ,-`                  ,   \\  ,.-\\       \\\n" +
            " /      ,               \\,-`\\`_,-`\\_,..--'\\\n" +
            ",`    ,/,              ,>,   )     \\--`````\\\n" +
            "(      `\\`---'`  `-,-'`_,<   \\      \\_,.--'`\n" +
            " `.      `--. _,-'`_,-`  |    \\\n" +
            "  [`-.___   <`_,-'`------(    /\n" +
            "  (`` _,-\\   \\ --`````````|--`\n" +
            "   >-`_,-`\\,-` ,          |\n" +
            " <`_,'     ,  /\\          /\n" +
            "  `  \\/\\,-/ `/  \\/`\\_/V\\_/\n" +
            "     (  ._. )    ( .__. )\n" +
            "     |      |    |      |\n" +
            "      \\,---_|    |_---./\n" +
            "      ooOO(_)    (_)OOoo\n";
        }
    }
}
