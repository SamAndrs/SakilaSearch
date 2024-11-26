using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorMovie_lookup
{
    public class Menu
    {
        public void PrintMenu()
        {
            Console.WriteLine(
               new string('=', 15) +
               " WELCOME TO SAKILA DATABASE " +
               new string('=', 25) + "\n\n"
               + new string(' ', 25)
               + "1). Search Actor by full name\n"
               + new string(' ', 25)
               + "Q). Quit application.\n"
               );

        }// End PrintMenuText()


        public string ReadStringInput(string prompt)
        {
            string value;
            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Invalid input, try again.");
                    continue;
                }
                return value;
            }
        }// End ReadStringInput()

    }


}
