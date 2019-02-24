﻿using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Project0Library
{
    public static class CreateData
    {
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
                        ConsoleDisplay.StoreList(storeLocations);
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
                ConsoleDisplay.StoreList(storeLocations);
                Console.WriteLine("Please enter a valid store Id for the order:");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var storeLocationId))
                {
                    if (storeLocations.Any(sL => sL.Id == storeLocationId))
                    {
                        ConsoleDisplay.CustomerList(customers);
                        Console.WriteLine("Please enter a valid customer Id for the order:");
                        input = Console.ReadLine();

                        if (int.TryParse(input, out var customerId))
                        {
                            if (customers.Any(c => c.Id == customerId))
                            {
                                ConsoleDisplay.CupcakeList();

                                Console.WriteLine("Please enter the name of a cupcake as it appears on the list:");
                                input = Console.ReadLine();

                                try
                                {
                                    Cupcake cupcakeType = (Cupcake)Enum.Parse(typeof(Cupcake), input);

                                    Console.WriteLine("Please enter the quantity you would like to order:");
                                    input = Console.ReadLine();

                                    if (int.TryParse(input, out var qnty))
                                    {
                                        int newOrderId = 1;
                                        if (orders.Count > 0) { newOrderId = orders.Max(o => o.Id) + 1; }

                                        orders.Add(new Order
                                        {
                                            Id = newOrderId,
                                            OrderLocation = storeLocationId,
                                            OrderCustomer = customerId,
                                            OrderTime = DateTime.Now,
                                            OrderItem = (cupcakeType, qnty)
                                        });
                                        string newData = JsonConvert.SerializeObject(orders, Formatting.Indented);
                                        File.WriteAllTextAsync(jsonOrders, newData).Wait();

                                        Console.WriteLine($"Order with id of {newOrderId} successfully created!");
                                    }
                                    else
                                    {
                                        logger.Error($"Invalid input {input}");
                                    }
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
    }
}