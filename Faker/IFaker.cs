using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    interface IFaker
    {
        //public T Create<T>();
        object Create(Type type);
    }
}
