using Newtonsoft.Json;
using NLog;
using Project0Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            string jsonLocations = @"C:\revature\luigi_cupcakes_locations.json";
            string jsonCustomers = @"C:\revature\luigi_cupcakes_customers.json";
            string jsonOrders = @"C:\revature\luigi_cupcakes_orders.json";
            LoadDataFromJSON(jsonLocations, 
                            jsonCustomers,
                            jsonOrders,
                            out var storeLocations, 
                            out var customers,
                            out var orders);
            
            Console.WriteLine("Welcome to Luigi's Cupcakes Manager");
            Console.WriteLine();
            Console.WriteLine("Please select from the following options (not case-sensitive):");

            while (true)
            {
                ConsoleDisplay.DisplayMenuAndGetInput(out var input);
                if (input == "S")
                {
                    CreateData.AddStoreLocation(jsonLocations, storeLocations);
                }
                if (input == "C")
                {
                    CreateData.AddCustomer(jsonCustomers, customers, storeLocations);
                }
                else if (input == "O")
                {
                    CreateData.AddOrder(jsonCustomers, jsonOrders, customers, storeLocations, orders);
                }
                else if (input == "SL")
                {
                    ConsoleDisplay.StoreList(storeLocations);
                }
                else if (input == "CL")
                {
                    ConsoleDisplay.CustomerList(customers);
                }
                else if (input == "OL")
                {
                    ConsoleDisplay.OrderList(orders);
                }
                else if (input == "OR")
                {
                    ConsoleDisplay.OrderRecommended(customers, orders);
                }
                else if (input == "Q")
                {
                    break;
                }
            }
        }

        public static void LoadDataFromJSON(string jsonLocations, 
                                            string jsonCustomers,
                                            string jsonOrders,
                                            out List<Location> storeLocations, 
                                            out List<Customer> customers,
                                            out List<Order> orders)
        {
            storeLocations = new List<Location>();
            if (File.Exists(jsonLocations))
            {
                string dataLocations = File.ReadAllTextAsync(jsonLocations).Result;
                storeLocations = JsonConvert.DeserializeObject<List<Location>>(dataLocations);
            }

            customers = new List<Customer>();
            if (File.Exists(jsonCustomers))
            {
                string dataCustomers = File.ReadAllTextAsync(jsonCustomers).Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(dataCustomers);
            }

            orders = new List<Order>();
            if (File.Exists(jsonOrders))
            {
                string dataOrders = File.ReadAllTextAsync(jsonOrders).Result;
                orders = JsonConvert.DeserializeObject<List<Order>>(dataOrders);
            }
        }
    }
}
