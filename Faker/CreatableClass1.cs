using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    public class CreatableClass1
    {
        public string Ass { get; set; }
        public CreatableClass1()
        {
           // Ass = "ass";
        }
        public CreatableClass1(string ass)
        {
             Ass = ass;
        }
    }
}
