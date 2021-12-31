using System;
using Faker;

namespace ULongGeneratorPlugin
{
    public class ULongGenerator : IGenerator
    {

        public Type GenerType => typeof(ulong);

        public object GetNewValue()
        {
            return (ulong)(new Random().Next());
        }
    }
}
