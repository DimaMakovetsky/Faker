using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
namespace Faker
{
    class Program
    {
        static void Main(string[] args)
        {
            var fakerObject = new FakerClass();
            double i= fakerObject.Create<double>();
            Console.WriteLine(i);
            float f = fakerObject.Create<float>();
            Console.WriteLine(f);
            int a = fakerObject.Create<int>();
            Console.WriteLine(a);
            short sh = fakerObject.Create<short>();
            Console.WriteLine(sh);
            long l = fakerObject.Create<long>();
            Console.WriteLine(l);
            bool b = fakerObject.Create<bool>();
            Console.WriteLine(b);
            char c = fakerObject.Create<char>();
            Console.WriteLine(c);
            string s = fakerObject.Create<string>();
            Console.WriteLine(s);
            DateTime date = fakerObject.Create<DateTime>();
            Console.WriteLine(date);
            byte by = fakerObject.Create<byte>();
            Console.WriteLine(by);
            Array array = fakerObject.Create<int[]>();
            Console.WriteLine("Array: ");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("List: "); 
            List<int> ass = fakerObject.Create<List<int>>();
            foreach (var item in ass)
            {
                Console.WriteLine(item);
            }

            //var faker = new Faker();
            User user = fakerObject.Create<User>();
            string userJson = JsonConvert.SerializeObject(user, Formatting.Indented);
            Console.WriteLine(userJson);
            //Enum en = fakerObject.Create<Enum>();
            //Console.WriteLine(en.ToString());
            /*foreach (var item in Enum.GetValues(en))
            {
                Console.WriteLine(item);
            }*/
            // CreatableClass1 creatable = fakerObject.Create<CreatableClass1>();
            //Console.WriteLine(creatable.Ass);

            //Console.WriteLine(creatable.GetType().GetFields());

        }
    }
}
