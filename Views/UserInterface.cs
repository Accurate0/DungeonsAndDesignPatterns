using System;

namespace DnDesignPattern.Views
{
    public class UserInterface
    {
        private View view;

        public UserInterface(View view)
        {
            this.view = view;
        }

        public string getInput(string prompt)
        {
            string str = null;
            do {
                Console.Write(prompt);
                str = Console.ReadLine();
            } while(str == null);

            return str;
        }

        public int getInput(string prompt, int min, int max)
        {
            var intVal = min - 1;

            do {
                Console.Write(prompt);
                var val = Console.ReadLine();
                try {
                    intVal = Convert.ToInt32(val);
                    if(intVal < min || intVal > max) {
                        view.DisplayWarning($"Invalid value, stay in range: {min} -> {max}");
                    }
                } catch(FormatException e) {
                    view.DisplayError(e.Message);
                }
            } while(intVal < min || intVal > max);

            return intVal;
        }
    }
}
