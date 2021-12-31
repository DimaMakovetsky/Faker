using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class CharGenerator:IGenerator
    {
        public Type GenerType => typeof(char);
        public object GetNewValue()
        {
            return (char)new Random().Next(65, 122);    
        }
    }
}
