using System;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Cupcake Manaager");

            Console.WriteLine("You have some number of options for your cupcake manager as follows:");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("S: Add a store location");
                Console.WriteLine("C: Add customer information");
                Console.WriteLine("2: Select a customer for an order");
                Console.WriteLine("3: Place an order at a store for a customer");
                Console.WriteLine("4: Get order statistics");
                Console.WriteLine("5: Check inventory");
                Console.WriteLine();
                Console.WriteLine("Please type a number selection such as '1', or type 'q' to quit: ");
                var input = Console.ReadLine();
                
                if (input == "S")
                {
                    Console.WriteLine("Please enter the store location name: ");
                    var fNameInput = Console.ReadLine();
                    // Need to check name uniqueness
                    Console.WriteLine("Please enter the customer's last name: ");
                    var lNameInput = Console.ReadLine();
                    //Console.WriteLine("Please enter the customer's first name: ");
                    //var fNameInput = Console.ReadLine();
                    //Console.WriteLine("Please enter the customer's first name: ");
                    //var fNameInput = Console.ReadLine();

                }
                if (input == "C")
                {
                    //Console.WriteLine("Please enter the customer's first name: ");
                    //var fNameInput = Console.ReadLine();
                    //Console.WriteLine("Please enter the customer's last name: ");
                    //var lNameInput = Console.ReadLine();
                    //Console.WriteLine("Please enter the customer's first name: ");
                    //var fNameInput = Console.ReadLine();
                    //Console.WriteLine("Please enter the customer's first name: ");
                    //var fNameInput = Console.ReadLine();

                }
                else if (input == "2")
                {

                }
                else if (input == "3")
                {

                }
                else if (input == "4")
                {

                }
                else if (input == "5")
                {

                }
                else if (input == "q")
                {
                    break;
                }
            }


        }
    }
}
