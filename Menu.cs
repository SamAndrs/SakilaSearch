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
            Console.Clear();
            Console.WriteLine(
               new string('=', 15) +
               " WELCOME TO SAKILA DATABASE " +
               new string('=', 15) + "\n\n"
               + new string(' ', 15)
               + "1). Search Actor by first name\n"
                + new string(' ', 15)
               + "2). Search Actor by last name\n"
                + new string(' ', 15)
               + "3). Search Actors by movie\n"
               + new string(' ', 15)
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
                    Console.WriteLine(new string(' ', 15) + "Invalid input, try again.");
                    continue;
                }
                return value;
            }
        }// End ReadStringInput()

    }


}
