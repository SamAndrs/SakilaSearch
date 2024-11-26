using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorMovie_lookup
{
    public class SearchView
    {
        private AdoHandler _adoHandler;

        private Menu _startMenu;

        public SearchView(AdoHandler setHandler, Menu setMenu)
        {
            _adoHandler = setHandler;

            _startMenu = setMenu;
        }

        public void SearchActorMovies()
        {
            string actorName = (_startMenu.ReadStringInput("Please enter Actor firstname: ") + _startMenu.ReadStringInput("Please enter Actor lastname: "));

            if(string.IsNullOrWhiteSpace(actorName))
            {
                Console.WriteLine("## ERROR ##: Actor name can not be empty");
                return;
            }

            try
            {
                var movies = _adoHandler.GetMoviesByActor(actorName);

                if(movies.Rows.Count > 0)
                {
                    Console.WriteLine("Movies featuring this actor:");
                    foreach(DataRow row in movies.Rows)
                    {
                        Console.WriteLine($"- {row["MovieTitle"]}");
                    }
                }
                else
                {
                    Console.WriteLine("There are no movies featuring this actor.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"## ERROR ## {ex.Message}");
            }
        }


    }
}
