using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class ShortGenerator:IGenerator
    {
        public Type GenerType => typeof(short);
        public object GetNewValue()
        {
            return (short)new Random().Next(short.MinValue, short.MaxValue);
        }
    }
}
