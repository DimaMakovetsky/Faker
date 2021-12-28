using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class LongGenerator:IGenerator
    {
        public Type GenerType => typeof(long);
        public object GetNewValue()
        {
            Random random = new Random();
            long result = random.Next(int.MinValue, int.MaxValue);
            result <<= 32;
            result |= (long)random.Next(int.MinValue, int.MaxValue) & int.MaxValue;
            return result;
        }
    }
}
