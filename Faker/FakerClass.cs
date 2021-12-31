using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Faker.GeneratorsOfAllTypes;
using System.Runtime.Serialization;
using System.Reflection;
namespace Faker
{
    public class FakerClass : IFaker
    {
        private readonly List<Type> circularReferences;

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
            LePlugin lePlugin = new LePlugin(generatorDictionary);
            lePlugin.LoadPluginGenerators();
            circularReferences = new List<Type>();
        }
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
        public object Create(Type t)
        {

            object toGenInst;

            //Console.WriteLine("Cringe");
            if (ToGenerateAbstract(t, out toGenInst))
                return toGenInst;
            //Console.WriteLine("Cringe2");
            if (ToGenerateWithValue(t, out toGenInst))
                return toGenInst;
            //Console.WriteLine("Cringe3");
            if (ToGenerateArray(t, out toGenInst))
            {
                return toGenInst;
            }
            //Console.WriteLine("Cringe4");

            if (ToGenerateList(t, out toGenInst))
                return toGenInst;
            if (ToGenerateCls(t, out toGenInst))
                return toGenInst;
            if (ToGenerateWithValue(t, out toGenInst))
                return toGenInst;
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
        private bool ToGenerateArray(Type type, out object toCreate)
        {
            toCreate = null;
            if (!type.IsArray)
                return false;
            toCreate = (new ArrayGenerator(this, type)).GetNewValue();
            return true;
        }
        private bool ToGenerateEnum(Type type, out object toCreate)
        {
            toCreate = null;
            if (!type.IsEnum)
                return false;
            Array values = type.GetEnumValues();
            Random random = new Random();
            toCreate = values.GetValue(random.Next(0, values.Length));
            return true;
        }
        private bool ToGenerateList(Type type, out object instance)
        {
            instance = null;
            if (!type.IsGenericType)
                return false;

            if (!(type.GetGenericTypeDefinition() == typeof(List<>)))
                return false;

            var innerTypes = type.GetGenericArguments();
            Type gType = innerTypes[0];
            int count = new Random().Next(1, 20);
            try
            {
                instance = Activator.CreateInstance(type);
            }
            catch (Exception)
            {
                return false;
            }
            object[] arr = new object[1];
            for (int i = 0; i < count; ++i)
            {
                arr[0] = Create(gType);
                try
                {
                    type.GetMethod("Add").Invoke(instance, arr);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }
        private bool ToGenerateCls(Type type, out object instance)
        {
            instance = null;

            if (!type.IsClass && !type.IsValueType)
                return false;

            if (circularReferences.Contains(type))
            {
                instance = default;
                return true;
            }

            circularReferences.Add(type);

            if (ToGenerateConstruct(type, out instance))
            {
                GenerateFillProps(instance, type);
                GenerateFillFields(instance, type);

                circularReferences.Remove(type);

                return true;
            }
            else
            {
                instance = FormatterServices.GetUninitializedObject(type);
                GenerateFillProps(instance, type);
                GenerateFillFields(instance, type);

                circularReferences.Remove(type);
                return true;
            }

            //return false;
        }

        private bool ToGenerateConstruct(Type type, out object instance)
        {
            instance = null;
            var ctns = type.GetConstructors();

            if (ctns.Length == 0)
                return false;

            Array.Sort(ctns, Comparer<ConstructorInfo>.Create((c1, c2) =>
                    c2.GetParameters().Length.CompareTo(c1.GetParameters().Length)));

            foreach (var locCtn in ctns)
            {
                if (locCtn.IsPublic)
                {
                    var prms = GenerateConstructorParams(locCtn);
                    try
                    {
                        instance = locCtn.Invoke(prms);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    return true;
                }
            }
            return false;
        }

        private void GenerateFillProps(object instance, Type type)
        {
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                if (!prop.CanWrite)
                    continue;

                if (prop.GetSetMethod() == null)
                    continue;

                prop.SetValue(instance, Create(prop.PropertyType));
            }
        }

        private void GenerateFillFields(object instance, Type type)
        {
            var fields = type.GetFields();

            foreach (var field in fields)
            {
                if (!field.IsPublic)
                    continue;

                field.SetValue(instance, Create(field.FieldType));
            }
        }

        private object[] GenerateConstructorParams(ConstructorInfo constructor)
        {
            var prms = constructor.GetParameters();
            object[] generated = new object[prms.Length];
            for (int i = 0; i < prms.Length; i++)
            {
                var p = prms[i];
                generated[i] = Create(p.ParameterType);
            }
            return generated;
        }
    }
}
