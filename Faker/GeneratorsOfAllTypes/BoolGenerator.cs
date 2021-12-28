using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class BoolGenerator:IGenerator
    {
        public Type GenerType => typeof(bool);
        public object GetNewValue()
        {
            double a = new Random().Next(0, 2);
            if (a < 1)
                return true;
            else
                return false;    
        }
    }
}
