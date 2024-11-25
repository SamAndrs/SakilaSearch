namespace ActorMovie_lookup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}



/*
 Skriv ett enkelt konsolprogram i C# som listar vilka filmer en skådespelare deltagit i.

Inmatningen ska vara att man anger ett skådespelarnamn.

Microsoft.Data.SqlClient



var connection = new SqlConnection(ConnectionString);
var command = new SqlCommand([string] "sqlQuery", [connection] connection);

connection.Open();

// command.ExecuteNonQuery();  		<-- används vid t.ex updates. returnerar endast antal påverkad rader som feedback.
var req = command.ExecuteReader(); 	<--hämtar information från en tabell (dvs utför Sql-queryn)
// command.ExecuteScalar();		<-- returnerar endast ett värde, från Scalar-functions
// command.ExecuteXmlReader();		<-- returnerar datan i excel format. 

if(req.HasRows)
{
	while(req.Read())
	{
		Console.WriteLine(req[1]);
		Console.WriteLine(req[2]);
	}
}

connection.Close();
 
 */