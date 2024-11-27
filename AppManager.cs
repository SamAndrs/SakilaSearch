using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorMovie_lookup
{
    public class AppManager
    {
        private Menu _startMenu;

        private SearchView _searchView;

        //private AdoHandler dbsHandler;

        public AppManager()
        {
            _startMenu = new Menu();
            _searchView = new SearchView(new AdoHandler(), _startMenu);
        }

        public void Run()
        {
            while (true)
            {
                _startMenu.PrintMenu();

                switch (_startMenu.ReadStringInput(new string(' ', 15) + "-->").ToUpper())
                {
                    case "1":
                        Console.WriteLine();
                        _searchView.SearchByFirstName();
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine();
                        _searchView.SearchByLastName();
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine();
                        _searchView.SearchActorsByMovie();
                        Console.ReadKey();
                        break;
                    case "Q":
                        Console.WriteLine(new string(' ', 15) + "Exiting application.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine(new string(' ', 15) + "## ERROR ##: Invalid option. Try again");
                        break;
                }
            }
        }// End Run()
    }
}
