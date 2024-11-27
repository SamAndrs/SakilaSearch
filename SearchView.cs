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

        public void SearchByFirstName()
        {
            string actorName = (_startMenu.ReadStringInput(new string(' ', 15) + "Please enter Actor firstname: "));

            CheckName(actorName);
            try
            {
                var movies = _adoHandler.MoviesByActorFirstName(actorName.ToUpper());
                CheckMovieRows(movies);

            }
            catch (Exception ex)
            {
                Console.WriteLine(new string(' ', 15) + $"## ERROR ## {ex.Message}");
            }
        }// End SearchByFirstName()

        public void SearchByLastName()
        {
            string actorLastName = _startMenu.ReadStringInput(new string(' ', 15) + "Please enter Actor last name: ");

            CheckName(actorLastName);
            try
            {
                var movies = _adoHandler.MoviesByActorLastName(actorLastName.ToUpper());
                CheckMovieRows(movies);
            }
            catch (Exception ex)
            {
                Console.WriteLine(new string(' ', 15) + $"## ERROR ## {ex.Message}");
            }
        }// End SearchByLastName()

        public void SearchActorsByMovie()
        {
            string movieName = _startMenu.ReadStringInput(new string(' ', 15) + "Please enter name of movie: ");

            CheckName(movieName);
            try
            {
                var actors = _adoHandler.ActorsByMovie(movieName.ToUpper());
                CheckActorRows(actors, movieName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(new string(' ', 15) + $"## ERROR! ## {ex.Message}");
            }
        }// End SearchActorsByMovie

        private void CheckName(string checkName)
        {
            if (string.IsNullOrWhiteSpace(checkName))
            {
                Console.WriteLine(new string(' ', 15) + "## ERROR! ##: Name can not be empty");
            }
        }// End CheckName

        private void CheckMovieRows(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                Console.WriteLine("Movies featuring this actor:");
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"- {row["MovieTitle"]}");
                }
            }
            else
            {
                Console.WriteLine(new string(' ', 15) + "There are no movies featuring an Actor with this name.");
            }
        }// End CheckDataRows()

        private void CheckActorRows(DataTable table, string movieName)
        {
            if (table.Rows.Count > 0)
            {
                Console.WriteLine($"Actors featured in the movie {movieName}:\n");
                foreach (DataRow row in table.Rows)
                {
                    string? firstName = row["first_name"].ToString();
                    string? lastName = row["last_name"].ToString();
                    Console.WriteLine($"{firstName} {lastName}");
                }
            }
            else
            {
                Console.WriteLine(new string(' ', 15) + "There is no such movie registered.");
            }
        }// End CheckActorRows()
    }
}
