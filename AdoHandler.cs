using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sql.Data.SqlClient;

namespace ActorMovie_lookup
{
    public class AdoHandler
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private AppManager appManager;
        
        /*
        public AdoHandler(AppManager setManager)
        {
            appManager = setManager;
        }*/

        public DataTable GetMoviesByActor(string actorName)
        {
            string query = @" 
            SELECT DISTINCT film.title AS MovieTitle
            FROM actor
            INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
            INNER JOIN film ON film_actor.film_id = film.film_id
            WHERE actor.first_name LIKE @actorName
            ORDER BY film.title;";

            DataTable movies = new DataTable();

            
             
             using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@actorName", $"%{actorName}%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(movies); // Populate DataTable with the query result
                    }
                }
            }

            return movies;
             
            
        }
    }
}
