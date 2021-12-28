using System;
using System.Reflection;

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
            // CreatableClass1 creatable = fakerObject.Create<CreatableClass1>();
            //Console.WriteLine(creatable.Ass);

            //Console.WriteLine(creatable.GetType().GetFields());

        }
    }
}
