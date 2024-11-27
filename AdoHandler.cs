using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ActorMovie_lookup
{
    public class AdoHandler
    {
        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DataTable MoviesByActorFirstName(string name)
        {
            string query = @" 
            SELECT DISTINCT film.title AS MovieTitle
            FROM actor
            INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
            INNER JOIN film ON film_actor.film_id = film.film_id
            WHERE actor.first_name LIKE @name
            ORDER BY film.title;";

            DataTable movies = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                SendQuery(query, connection, name, movies);

                connection.Close();
            }
            return movies;
        }// End MoviesByActorFirstName()

        public DataTable MoviesByActorLastName(string name)
        {
            string query = @"
            SELECT DISTINCT film.title AS MovieTitle
            FROM actor
            INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
            INNER JOIN film ON film_actor.film_id = film.film_id
            WHERE actor.last_name LIKE @name
            ORDER BY film.title;";

            DataTable movies = new DataTable();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SendQuery(query, connection, name, movies);
                
                connection.Close();
            }
            return movies;
        }// End MoviesByActorLastName()

        public DataTable ActorsByMovie(string name)
        {
            
            string query = @"
            SELECT actor.first_name, actor.last_name
            FROM actor
            INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
            INNER JOIN film ON film_actor.film_id = film.film_id
            WHERE film.title LIKE @name
            ORDER BY actor.last_name
            THEN BY actor.first_name
            ;";
            //THEN BY DESCENDING actor.first_name;";
            /*
            string query = @"
            SELECT a.first_name, a.last_name
            FROM actor a
            JOIN film_actor fa ON a.actor_id = fa.actor_id
            JOIN film f ON fa.film_id = f.film_id
            WHERE f.title LIKE @name;";
            */

            DataTable actors = new DataTable();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SendQuery(query,connection,name, actors);

                connection.Close();
            }
            return actors;
        }

        private void SendQuery(string thisQuery, SqlConnection thisConn, string thisName, DataTable thisTable)
        {
            using (SqlCommand command = new SqlCommand(thisQuery, thisConn))
            {
                command.Parameters.AddWithValue("@name", $"%{thisName}%");

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(thisTable);
                }
            }
        }// End SendQuery()
    }
}
