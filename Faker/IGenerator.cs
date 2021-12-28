using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    public interface IGenerator
    {
        Type GenerType { get; }
        object GetNewValue();
    }
}
