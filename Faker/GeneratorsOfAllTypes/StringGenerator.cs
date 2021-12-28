using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class StringGenerator:IGenerator
    {
        public Type GenerType => typeof(string);
        public object GetNewValue()
        {
            int a = new Random().Next(1,40);
            string s="";
            CharGenerator charGenerator = new CharGenerator();
            for (int i = 0; i < a; i++)
                s += charGenerator.GetNewValue();
            
            return s;    
        }
    }
}
