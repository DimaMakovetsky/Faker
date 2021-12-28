using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class LePlugin
    {
        
        private Dictionary<Type, IGenerator> generatorDictionary;
        public LePlugin(Dictionary<Type,IGenerator> dic)
        {
            generatorDictionary = dic;
        }
        public void LoadPluginsCaller()
        {
            //Assembly ass = Assembly;
        }
        private void LoadPlugins(Assembly ass)
        {
            Type genType = ass.GetTypes().FirstOrDefault(type => typeof(IGenerator).IsAssignableFrom(type));
            if (genType == null)
                return;
            if (genType.FullName == null)
                return;
            if (!genType.IsClass)
                return;
            if (ass.CreateInstance(genType.FullName) is IGenerator genPlugin)
                generatorDictionary.Add(genPlugin.GenerType, genPlugin);
        }
    }
}
