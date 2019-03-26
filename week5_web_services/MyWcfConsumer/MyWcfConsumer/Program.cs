using MyWcfConsumer.MyService;
using MyWcfConsumer.MyService2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWcfConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var client = new Service1Client())
            {
                client.Open();

                var version = await client.GetServiceVersionAsync();
                Console.WriteLine(version);

                Console.WriteLine("Enter number: ");
                if (int.TryParse(Console.ReadLine(), out var num))
                {
                    var doubled = await client.DoubleNumberAsync(num);

                    Console.WriteLine($"Doubled: {doubled}");
                }
                else
                {
                    Console.WriteLine("Not a number!");
                }

                MyService.Question question = client.GetQuestion(1);
                Console.WriteLine(question.QuestionId);
                // can't access datemodified

                MyService.Question question12 = client.GetQuestion(2);
                Console.WriteLine(question.QuestionId);

            }

            using (var client = new Service2Client())
            {
                client.Open();

                

                // Dealing with Question list
                QuestionList newList = client.CreateQuestionList();




            }



            Console.ReadKey();

        }
    }
}
