using DnDesignPattern.Views;

namespace DnDesignPattern.Controller.States
{
    /// <summary>
    /// One of the simplest states, just contains what need to be
    /// done when the game ends, there's 2 possible things that happens
    /// the game ends, if you beat the dragon you win, and it's over,
    /// if you die to the dragon or before it's dead, you lose
    /// </summary>
    public class GameOverState : State
    {
        private View view;
        private bool dragonDefeated;
        public GameOverState(GameEngine context, UserInterface ui, View view, bool dragonDefeated) : base(context, ui)
        {
            this.view = view;
            this.dragonDefeated = dragonDefeated;
        }

        // ASCII Art Reference: https://ascii.co.uk/art/death
        public override void Action()
        {
            if(dragonDefeated) {
                view.DisplayMessage("Congratulations! You have defeated the dragon!");
            } else {
                view.Display(
                    "            ...\n" +
                    "          ;::::;\n" +
                    "        ;::::; :;\n" +
                    "      ;:::::'   :;\n" +
                    "     ;:::::;     ;.\n" +
                    "    ,:::::'       ;              OOO\\\n" +
                    "    ::::::;       ;             OOOOO\\\n" +
                    "    ;:::::;       ;            OOOOOOOO\n" +
                    "    ,;::::::;     ;'           / OOOOOOO\n" +
                    "    ;:::::::::`. ,,,;.        /  / DOOOOOO\n" +
                    ".';:::::::::::::::::;,       /  /     DOOOO\n" +
                    ",::::::;::::::;;;;::::;,    /  /        DOOO\n" +
                    ";`::::::`'::::::;;;::::: ,#/  /          DOOO\n" +
                    ":`:::::::`;::::::;;::: ;::#  /            DOOO\n" +
                    "::`:::::::`;:::::::: ;::::# /              DOO\n" +
                    "`:`:::::::`;:::::: ;::::::#/               DOO\n" +
                    ":::`:::::::`;; ;:::::::::##                OO\n" +
                    "::::`:::::::`;::::::::;:::#                OO\n" +
                    "`:::::`::::::::::::;'`:;::#                O\n" +
                    " `:::::`::::::::;' /  / `:#\n" +
                    "  ::::::`:::::;'  /  /   `#\n"
                );

                view.DisplayRed(
                    "██    ██  ██████  ██    ██     ██████  ██ ███████ ██████ \n" +
                    " ██  ██  ██    ██ ██    ██     ██   ██ ██ ██      ██   ██ \n" +
                    "  ████   ██    ██ ██    ██     ██   ██ ██ █████   ██   ██ \n" +
                    "   ██    ██    ██ ██    ██     ██   ██ ██ ██      ██   ██ \n" +
                    "   ██     ██████   ██████      ██████  ██ ███████ ██████  \n"
                );
            }

            Context.Pop();
        }
    }
}
