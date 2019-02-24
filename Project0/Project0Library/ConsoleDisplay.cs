using System;
using System.Collections.Generic;
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
            Console.WriteLine("'CL': Get a list of available customers and their information.");
            Console.WriteLine("'OL': Get a list of orders that have been placed.");
            Console.WriteLine();
            Console.WriteLine("Please type a selection , or type 'q' to quit: ");
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
                    $"Customer Id, {item.OrderCustomer}, Order Time: {item.OrderTime}, " +
                    $"Order Item: {item.OrderItem.Item1}, qnty: {item.OrderItem.Item2}");
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
