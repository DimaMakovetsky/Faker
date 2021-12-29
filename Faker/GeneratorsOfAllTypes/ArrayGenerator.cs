using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    class ArrayGenerator:IGenerator
    {
        public Type GenerType => typeof(Array);
        private IFaker faker;
        private Type arrType;
        public ArrayGenerator(IFaker faker, Type type)
        {
            this.faker = faker;
            arrType = type;
        }
        public object GetNewValue()
        {
            var elementType = arrType.GetElementType();
            if (elementType == null)
            {
                Console.WriteLine("Huper Cringe");
                return null;
            }
            var length = new Random().Next(0, 9);
            var result = Array.CreateInstance(elementType, length);
            for (int i = 0; i < length; i++)
                result.SetValue(faker.Create(elementType), i);
            return result;
            //return (short)new Random().Next(short.MinValue, short.MaxValue);
        }
    }
}
