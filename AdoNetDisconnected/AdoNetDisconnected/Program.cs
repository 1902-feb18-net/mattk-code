using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDisconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter condition: ");
            var condition = Console.ReadLine();
            var commandString = $"SELECT * FROM Movie.Genre WHERE {condition}";

            // disconnected architecture
            // rather than maximizing the speed of getting the results
            // we want to minimize the time the connection spends open

            // still need NuGet package System.Data.SqlClient (for SQL Server)

            // System.Data.DataSet can store data that DataReader gets,
            // with the help of DataAdapter.
            var dataSet = new DataSet();

            var connectionString = SecretConfiguration.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandString, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    // step 2. execute the query, filling the dataset
                    adapter.Fill(dataSet);
                    
                }
                // step 3, close the connection
                connection.Close();
            }

            // process the results as step 4
            // (not while connection is open, to get is closed ASAP)

            // inside DataSet is some DataTables
            // inside DataTable is DataColumn, DataRow
            // inside DataRow is object[]

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DataColumn idCol = dataSet.Tables[0].Columns["GenreId"];
                Console.WriteLine($"Genre #{row[idCol]}: {row[1]}");
            }

            Console.ReadLine();
        }
    }
}
