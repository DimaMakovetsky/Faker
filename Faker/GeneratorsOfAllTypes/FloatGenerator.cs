using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class FloatGenerator:IGenerator
    {
        public Type GenerType => typeof(float);
        public object GetNewValue()
        {
            return (float)new Random().NextDouble() * 10000;
        }
    }
}
