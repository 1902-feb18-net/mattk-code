using MoreLinq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0Library
{
    public static class ConsoleDisplay
    {
        public static void DisplayMenuAndGetInput(out string input)
        {
            Console.WriteLine();
            Console.WriteLine("'S': Add a store location to the database.");
            Console.WriteLine("'C': Add a customer to the database.");
            Console.WriteLine("'O': Add an order to the database.");
            Console.WriteLine("'SL': Get a list of available stores and their id numbers.");
            Console.WriteLine("'SO': Get a store's order history.");
            Console.WriteLine("'CL': Get a list of available customers and their information.");
            Console.WriteLine("'CS': Search for customers by name.");
            Console.WriteLine("'CO': Get a customer's order history.");
            Console.WriteLine("'OL': Get a list of all orders that have been placed.");
            Console.WriteLine("'OR': Get a customer's recommended order.");
            Console.WriteLine();
            Console.WriteLine("Please type a selection, or type 'q' to quit: ");
            input = Console.ReadLine().ToUpper();
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

        public static void StoreOrders(List<Location> storeLocations)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            StoreList(storeLocations);
            Console.WriteLine("Please enter the store id to get that store's orders:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var storeLocationId))
            {
                foreach (var item in storeLocations.Where(sL => sL.Id == storeLocationId))
                {
                    Console.WriteLine($"Store Location {storeLocationId}");
                    OrderList(item.OrderHistory, null);
                }
            }
            else
            {
                logger.Error($"Invalid input {input}");
            }
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

        public static void CustomerSearch(List<Customer> customers)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            Console.WriteLine("Please enter the first name of the customer:");
            var input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input))
            {
                var numPossibleMatches = customers.Count(c => c.FirstName == input);
                if (numPossibleMatches > 0)
                {
                    Console.WriteLine($"Found {numPossibleMatches} with that first name.");
                    var possibleMatches = customers.Where(c => c.FirstName == input);
                    List<Customer> customerList = new List<Customer>();
                    foreach (var item in possibleMatches)
                    {
                        customerList.Add(item);
                    }
                    Console.WriteLine("Please enter the last name of the customer:");
                    input = Console.ReadLine();
                    if (!String.IsNullOrEmpty(input))
                    {
                        numPossibleMatches = customerList.Count(c => c.LastName == input);
                        if (numPossibleMatches > 0)
                        {
                            possibleMatches = customerList.Where(c => c.LastName == input);
                            Console.WriteLine("List of customer's with that first name and last name:");
                            foreach (var item in possibleMatches)
                            {
                                Console.WriteLine($"Customer Id: {item.Id}, First Name: {item.FirstName}, " +
                                $"Last Name, {item.LastName}, Default Store Id: {item.DefaultStore}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no one in the system with that first name and last name.");
                        }
                    }
                    else
                    {
                        logger.Error("Empty input for last name is invalid.");
                    }
                }
                else
                {
                    Console.WriteLine("There is no one in the system with that first name.");
                }
            }
            else
            {
                logger.Error("Empty input for first name is invalid.");
            }
        }

        public static void CustomerOrders(List<Customer> customers)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            CustomerList(customers);
            Console.WriteLine("Please enter the customer id to get that customer's orders:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var customerId))
            {
                foreach (var item in customers.Where(c => c.Id == customerId))
                {
                    Console.WriteLine($"Customer {item.FirstName} {item.LastName}");
                    OrderList(item.OrderHistory, null);
                }
            }
            else
            {
                logger.Error($"Invalid input {input}");
            }
        }

        public static void OrderList(List<Order> orders, List<Location> storeLocations)
        {
            Console.WriteLine();
            Console.WriteLine("Please select from the following filters ('n' for no filter)");
            Console.WriteLine("'E': Earliest orders first");
            Console.WriteLine("'L': Latest orders first");
            Console.WriteLine("'C': Cheapest orders first");
            Console.WriteLine("'X': Most expensive orders first");
            Console.WriteLine();
            Console.WriteLine("Please type a selection to see a list of orders: ");
            var input = Console.ReadLine().ToUpper();
            List<Order> modOrders = new List<Order>();

            if (input == "E")
            {
                foreach (var item in orders.OrderBy(o => o.OrderTime))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(modOrders, storeLocations, "List of Orders (earliest to latest):");
            }
            else if (input == "L")
            {
                foreach (var item in orders.OrderByDescending(o => o.OrderTime))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(modOrders, storeLocations, "List of Orders (latest to earliest):");
            }
            else if (input == "C")
            {
                foreach (var item in orders.OrderBy(o => (o.OrderItem.Item2 * o.OrderItem.Item1.Cost)))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(modOrders, storeLocations, "List of Orders (cheapest to most expensive):");
            }
            else if (input == "X")
            {
                foreach (var item in orders.OrderByDescending(o => (o.OrderItem.Item2 * o.OrderItem.Item1.Cost)))
                {
                    modOrders.Add(item);
                }
                DisplayOrders(modOrders, storeLocations, "List of Orders (most expensive to cheapest):");
            }
            else
            {
                DisplayOrders(orders, storeLocations, "List of Orders:");
            }
        }

        public static void DisplayOrders(List<Order> orders, List<Location> storeLocations, string prompt)
        {
            Console.WriteLine(prompt);
            Console.WriteLine();
            foreach (var item in orders)
            {
                Console.WriteLine($"Order Id: {item.Id}, Location Id: {item.OrderLocation}, " +
                    $"Customer Id, {item.OrderCustomer}, Order Time: {item.OrderTime}, " +
                    $"Order Item: {item.OrderItem.Item1}, qnty: {item.OrderItem.Item2}");
                Console.WriteLine($"Order Id {item.Id} total cost: " +
                    $"${item.OrderItem.Item2 * item.OrderItem.Item1.Cost}");
            }
            Console.WriteLine();
            Console.WriteLine("Other order statistics...:");
            Console.WriteLine($"Average Order Cost: " +
                $"{orders.Average(o => o.OrderItem.Item2 * o.OrderItem.Item1.Cost)}");
            Console.WriteLine($"Order with the latest date: " +
                $"{orders.Max(o => o.OrderTime)}");
            if (!(storeLocations is null))
            {
                var storeWithMostOrders = storeLocations.MaxBy(sL => sL.OrderHistory.Count()).First();
                Console.WriteLine($"Store Id with the most orders: {storeWithMostOrders.Id}");
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

        public static void OrderRecommended(List<Customer> customers, List<Order> orders)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            ConsoleDisplay.CustomerList(customers);
            Console.WriteLine("Please enter a valid customer Id to display recommended order:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var customerId))
            {
                if (customers.Any(c => c.Id == customerId))
                {
                    var customer = customers.Single(c => c.Id == customerId);
                    var customerOrders = orders.Where(o => o.OrderCustomer == customerId);
                    // https://stackoverflow.com/questions/6730974/select-most-frequent-value-using-linq
                    var mostFrequentOrder = customerOrders.GroupBy(o => o.OrderItem.Item1)
                                                         .OrderByDescending(gp => gp.Count())
                                                         .Take(1);
                    // https://code.i-harness.com/en/q/820541
                    var intermediate = mostFrequentOrder.First();
                    string orderRecommended = "not assigned";
                    foreach (var item in intermediate)
                    {
                        orderRecommended = item.OrderItem.Item1.ToString();
                        break;
                    }

                    if (orderRecommended == "not assigned")
                    {
                        logger.Error($"Unable to find recommended order for customer {customer.FirstName}" +
                            $" {customer.LastName}");
                    }
                    else
                    {
                        Console.WriteLine($"Order recommended count: {mostFrequentOrder.Count()}");
                        Console.WriteLine($"Recommended Order for Customer {customer.FirstName}" +
                            $" {customer.LastName}: {orderRecommended}");
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
    }
}
