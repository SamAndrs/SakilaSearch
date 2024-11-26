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
            //dbsHandler = new AdoHandler(this);
            _searchView = new SearchView(new AdoHandler(this), _startMenu);

            _startMenu = new Menu();
            //_startMenu.PrintMenu();

        }

        public void Run()
        {
            while (true)
            {
                _startMenu.PrintMenu();

                switch (_startMenu.ReadStringInput("-->").ToUpper())
                {
                    case "1":
                        _searchView.SearchActorMovies();
                        break;
                    case "Q":
                        Console.WriteLine("Exiting application.");
                        return;
                    default:
                        Console.WriteLine("## ERROR ##: Invalid option. Try again");
                        break;
                }
            }



        }// End Run()
    }
}
