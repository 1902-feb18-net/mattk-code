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
                DisplayMenu(out var input);
                if (input == "S")
                {
                    AddStoreLocation(jsonLocations, storeLocations);
                }
                if (input == "C")
                {
                    AddCustomer(jsonCustomers, customers, storeLocations);
                }
                else if (input == "O")
                {
                    AddOrder(jsonCustomers, jsonOrders, customers, storeLocations, orders);
                }
                else if (input == "SL")
                {
                    StoreList(storeLocations);
                }
                else if (input == "CL")
                {
                    CustomerList(customers);
                }
                else if (input == "OL")
                {
                    OrderList(orders);
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

        public static void DisplayMenu(out string input)
        {
            Console.WriteLine();
            Console.WriteLine("'S': Add a store location to the database.");
            Console.WriteLine("'C': Add a customer to the database.");
            Console.WriteLine("'O': Add an order to the database.");
            Console.WriteLine("'SL': Get a list of available stores and their id numbers.");
            Console.WriteLine("'CL': Get a list of available customers and their information.");
            Console.WriteLine("'OL': Get a list of orders that have been placedf.");
            Console.WriteLine();
            Console.WriteLine("Please type a selection , or type 'q' to quit: ");
            input = Console.ReadLine().ToUpper();
        }

        public static void AddStoreLocation(string jsonLocations, List<Location> storeLocations)
        {
            int newLocationId = 1;
            if (storeLocations.Count > 0) { newLocationId = storeLocations.Max(sL => sL.Id) + 1; }

            storeLocations.Add(new Location { Id = newLocationId });
            string newData = JsonConvert.SerializeObject(storeLocations, Formatting.Indented);
            File.WriteAllTextAsync(jsonLocations, newData).Wait();
            Console.WriteLine($"Location with id of {newLocationId} successfully created!");
        }

        public static void AddCustomer(string jsonCustomers, List<Customer> customers, 
            List<Location> storeLocations)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();
            Console.WriteLine("Please enter a first name:");
            var input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                var fName = input;
                Console.WriteLine("Please enter a last name:");
                input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    var lName = input;
                    if (storeLocations.Count > 0)
                    {
                        StoreList(storeLocations);
                        Console.WriteLine("Please enter a valid Id for default store location:");
                        input = Console.ReadLine();

                        if (int.TryParse(input, out var storeLocationId))
                        {
                            if (storeLocations.Any(sL => sL.Id == storeLocationId))
                            {
                                int newCustomerId = 1;
                                if (customers.Count > 0) { newCustomerId = customers.Max(c => c.Id) + 1; }

                                customers.Add(new Customer
                                {
                                    Id = newCustomerId,
                                    FirstName = fName,
                                    LastName = input,
                                    DefaultStore = storeLocationId
                                });
                                string newData = JsonConvert.SerializeObject(customers, Formatting.Indented);
                                File.WriteAllTextAsync(jsonCustomers, newData).Wait();

                                Console.WriteLine($"Location with id of {newCustomerId} successfully created!");
                            }
                            else
                            {
                                logger.Error($"{storeLocationId} is not in the list of stores.");
                            }
                        }
                        else
                        {
                            logger.Error($"Invalid input {input}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You must add at least one store before you can add a customer.");
                    }
                }
                else
                {
                    logger.Error("Empty input for last name is invalid.");
                }
            }
            else
            {
                logger.Error("Empty input for first name is invalid.");
            }
        }

        public static void AddOrder(string jsonCustomers,
                                    string jsonOrders,
                                    List<Customer> customers,
                                    List<Location> storeLocations,
                                    List<Order> orders)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            if (storeLocations.Count > 0 && customers.Count > 0)
            {
                StoreList(storeLocations);
                Console.WriteLine("Please enter a valid store Id for the order:");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var storeLocationId))
                {
                    if (storeLocations.Any(sL => sL.Id == storeLocationId))
                    {
                        CustomerList(customers);
                        Console.WriteLine("Please enter a valid customer Id for the order:");
                        input = Console.ReadLine();

                        if (int.TryParse(input, out var customerId))
                        {
                            if (customers.Any(c => c.Id == customerId))
                            {
                                CupcakeList();

                                Console.WriteLine("Please enter the name of a cupcake as it appears on the list:");
                                input = Console.ReadLine();

                                try
                                {
                                    Enum.Parse(typeof(Cupcake), input);

                                    int newOrderId = 1;
                                    if (orders.Count > 0) { newOrderId = orders.Max(o => o.Id) + 1; }

                                    orders.Add(new Order
                                    {
                                        Id = newOrderId,
                                        OrderLocation = storeLocationId,
                                        OrderCustomer = customerId,
                                        OrderTime = DateTime.Now,
                                    });
                                    string newData = JsonConvert.SerializeObject(orders, Formatting.Indented);
                                    File.WriteAllTextAsync(jsonOrders, newData).Wait();

                                    Console.WriteLine($"Order with id of {newOrderId} successfully created!");
                                }
                                catch (SystemException ex)
                                {
                                    logger.Error(ex);
                                }
                            }
                            else
                            {
                                logger.Error($"{customerId} is not in the list of customers.");
                            }
                        }
                        else
                        {
                            logger.Error($"Invalid input {input}");
                        }
                    }
                    else
                    {
                        logger.Error($"{storeLocationId} is not in the list of stores.");
                    }
                }
                else
                {
                    logger.Error($"Invalid input {input}");
                }
            }
            else
            {
                Console.WriteLine("You must add at least one store and one customer before you can place an order.");
            }
        }

        public static void StoreList(List<Location> storeLocations)
        {
            Console.WriteLine("List of Available Store Locations:");
            Console.WriteLine();
            foreach (var item in storeLocations)
            {
                Console.WriteLine($"Store Id: {item.Id}");
            }
            Console.WriteLine();
        }

        public static void CustomerList(List<Customer> customers)
        {
            Console.WriteLine("List of Customers:");
            Console.WriteLine();
            foreach (var item in customers)
            {
                Console.WriteLine($"Customer Id: {item.Id}, First Name: {item.FirstName}, " +
                    $"Last Name, {item.LastName}, Default Store Id: {item.DefaultStore}");
            }
            Console.WriteLine();
        }

        public static void OrderList(List<Order> orders)
        {
            Console.WriteLine("List of Orders:");
            Console.WriteLine();
            foreach (var item in orders)
            {
                Console.WriteLine($"Order Id: {item.Id}, Location Id: {item.OrderLocation}, " +
                    $"Customer Id, {item.OrderCustomer}, Order Time: {item.OrderTime}");
            }
            Console.WriteLine();
        }

        public static void CupcakeList()
        {
            Console.WriteLine("List of Cupcakes:");
            Console.WriteLine();
            Console.WriteLine("Vanilla");
            Console.WriteLine("Chocolate");
            Console.WriteLine("ChocPeanutButter");
            Console.WriteLine("RaspAmaretto");
            Console.WriteLine("ChocPeppermint");
            Console.WriteLine("MintOreo");
            Console.WriteLine("Coconut");
            Console.WriteLine("Lemon");
            Console.WriteLine();

        }
    }
}
