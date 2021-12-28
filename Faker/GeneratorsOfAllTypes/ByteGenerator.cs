using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class ByteGenerator:IGenerator
    {
        public Type GenerType => typeof(byte);
        public object GetNewValue()
        {
            return (byte)new Random().Next(byte.MinValue, byte.MaxValue);
        }
    }
}
