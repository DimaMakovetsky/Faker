using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class IntGenerator:IGenerator
    {
        public Type GenerType => typeof(int);
        public object GetNewValue()
        {
            return new Random().Next(0, 10000);
        }
    }
}
