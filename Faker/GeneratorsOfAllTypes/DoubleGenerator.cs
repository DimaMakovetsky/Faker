using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class DoubleGenerator:IGenerator
    {
        public Type GenerType => typeof(double);
        public object GetNewValue()
        {
            return new Random().NextDouble() * 10000;    
        }
    }
}
