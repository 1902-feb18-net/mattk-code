using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project0Library
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DefaultStore { get; set; }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public DateTime LastOrder { get; set; }
        public int LastStoreOrder { get; set; }

        public static int AddCustomer(string jsonCustomers, List<Customer> customers,
            List<Location> storeLocations, string fName, string lName, int storeLocationId)
        {
            int newCustomerId = 1;
            if (customers.Count > 0) { newCustomerId = customers.Max(c => c.Id) + 1; }

            customers.Add(new Customer
            {
                Id = newCustomerId,
                FirstName = fName,
                LastName = lName,
                DefaultStore = storeLocationId
            });
            string newData = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllTextAsync(jsonCustomers, newData).Wait();

            return newCustomerId;
        }

        public static bool CheckCustomerExists(int customerId, List<Customer> customers)
        {
            if (customers.Any(c => c.Id == customerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
