using System;
using Faker;
namespace UintGener
{
    public class UintGenerator:IGenerator
    {
        public Type GenerType => typeof(uint);

        public object GetNewValue()
        {
            return (uint)(new Random().Next());
        }
    }
}
