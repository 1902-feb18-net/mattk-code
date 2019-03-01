using System;
using System.Data.SqlClient;

namespace AdoNetConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADO.NET  
            // originally Active Data Objects, ADO. later ADO.NET
            // ADO.NET is the "brand name"/"namespace" for all .NET data access stuff
            // but in practive, when we day "ADO.NET", we mean the old fashioned way
            // we're about to see.

            var connString = SecretConfiguration.ConnectionString;

            Console.WriteLine("Enter condition: ");
            var condition = Console.ReadLine();
            var commString = $"SELECT * FROM Movie.Movie WHERE {condition};";

            // SQL injection:
            // user could enter "1 = 1; DROP TABLE Movie.Movie" and I drop table.

            // solution: sanitize and validate all user input.

            // for connected architecture:
            // 1. open the connection
            // we should be catching exceptions and handling them properly
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                // 2. execute query
                //var commString = "SELECT * FROM Movie.Movie;";
                using (var command = new SqlCommand(commString, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        // we have command.ExecuteReader which returns a DataReader
                        // for SELECT queries...
                        // and we have command.ExecuteNonQuery which just returns number of
                        // rows affected, for DELETE, INSERT, etc.
                        
                        // 3. process the results.
                        if (reader.HasRows)
                        {
                            // reader.Read advances the "cursor" through the results 
                            // one row at a time
                            // the results are comiong in to the computer's network buffer
                            // and DataReader is reading them each as soon as they come in
                            // (networks are slow compared to code)
                            while (reader.Read())
                            {
                                object id = reader["MovieId"];
                                object title = reader["Title"];
                                object fullTitle = reader[4]; // fifth column

                                // i could do downcasting and instantiate some
                                // Movie class. or just print results directly

                                Console.WriteLine($"Movie #{id}: {fullTitle}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows returned.");
                        }

                        // 4. close the connection
                        connection.Close();

                    }
                }
            }

        }
    }
}
