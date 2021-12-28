using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Faker.GeneratorsOfAllTypes;
namespace Faker
{
    class FakerClass:IFaker
    {
       
        private Dictionary<Type, IGenerator> generatorDictionary;
        public FakerClass()
        {
            generatorDictionary = new Dictionary<Type, IGenerator>
            {
                {typeof(bool),  new BoolGenerator()},
                {typeof(int),  new IntGenerator()},
                {typeof(double),  new DoubleGenerator()},
                {typeof(char),  new CharGenerator()},
                {typeof(string),  new StringGenerator()},
                {typeof(DateTime),  new DateGenerator()},
                {typeof(byte),  new ByteGenerator()},
                {typeof(float),  new FloatGenerator() }, 
                {typeof(long),  new LongGenerator()},
                {typeof(short),  new ShortGenerator()}
            };
            //LePlugin lePlugin = new LePlugin(generatorDictionary);
            
        }
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
        public object Create(Type t)
        {

            //typeof(t) newObject = new t();

            object toCreate;
            if (ToGenerateAbstract(t, out toCreate))
                return toCreate;
            if (ToGenerateWithValue(t, out toCreate))
                return toCreate;
            return default;
        }
        private bool ToGenerateAbstract(Type t, out object toCreate)
        {
            toCreate = default;
            if (!t.IsAbstract)
                return false;
            return true;
        }
        private bool ToGenerateWithValue(Type t, out object toCreate)
        {
            toCreate = null;
            if (generatorDictionary.TryGetValue(t, out IGenerator generator))
            {
                toCreate = generator.GetNewValue();
                return true;
            }
            return false;
        }
    }
}
