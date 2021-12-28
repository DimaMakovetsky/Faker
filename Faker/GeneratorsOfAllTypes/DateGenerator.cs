using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.GeneratorsOfAllTypes
{
    public class DateGenerator:IGenerator
    {
        public Type GenerType => typeof(DateTime);
        public object GetNewValue()
        {
            return new DateTime(new Random().Next(1, 2021), new Random().Next(1, 12), new Random().Next(1, 28), new Random().Next(0, 23), new Random().Next(0, 59), new Random().Next(0, 59));
        }
    }
}
