using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationAndAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    id = 1,
                    Name = "Nick",
                    Address = new Address
                    {
                        Street = "123 Main St",
                    City = "Fort Worth",
                    State = "TX"

                    }

                },
                new Person
                {
                    id = 2,
                    Name = "Fred",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Reston",
                        State = "VA"

                    }

                }
            };

            // to send this over network or to disk, we need to serialize it.
            // meaning, collecting data from across memory locations into a 
            // well-defined text or binary format.
            // ideally this is reversible, we can deserialize the data back from its format into memory
            // (maybe on the other end of the network connection).

            // normally, \ is used as an excape character in string literals.
            // so, this string has a new line character
            string newline = "\n";
            // when we want to treat backslashes literally, we have @ strings...
            string fileName = @"C:\revature\persons_data.xml";

            persons = DeserializeXMLFromFileAsync(fileName).Result;

            persons.Add(new Person { id = persons.Max(p => p.id) + 1 });

            SerializeAsXMLToFile(fileName, persons);

            string jsonFile = @"C:\revature\persons_data.json";

            string data = File.ReadAllTextAsync(jsonFile).Result;
            persons = JsonConvert.DeserializeObject<List<Person>>(data);

            persons.Add(new Person { id = persons.Max(p => p.id) + 1 });
            string newData = JsonConvert.SerializeObject(persons);
            File.WriteAllTextAsync(jsonFile, newData).Wait();
        }

        // async code requires async tests
       

        private static void SerializeAsXMLToFile(string fileName, List<Person> persons)
        {
            // our first object, SmlSerializer
            // does not know about generics
            var serializer = new XmlSerializer(typeof(List<Person>));

            // Create mode to overwrite file if already exists.
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, persons);
            }
            catch (IOException e)
            {
                Console.WriteLine("error in writing to file:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                fileStream?.Dispose();
            }
            
        }

        private static async Task<List<Person>> DeserializeXMLFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            // in addition to those XmlBlahBlah attributes, we can also customize
            // the format of the serializer object itself


            //FileStream fileStream = null;
            //var memoryStream = new MemoryStream();

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    // copy the filestream into the memorystream
                    await fileStream.CopyToAsync(memoryStream);
                    // The objects you are using need to support Async, or you can't use itr
                }

                memoryStream.Position = 0;

                return (List<Person>) serializer.Deserialize(memoryStream);
                // should be try-catching throughout this process

                
                
            }

        }
    }
}
