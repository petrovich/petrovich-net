using System;
using System.IO;
using System.Reflection;
using NPetrovich.Rules.Parser.Yaml;

namespace NPetrovich.Rules.Loader
{
    public class EmbeddedResourceLoader : IRulesLoader
    {
        public Data.Rules Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "NPetrovich.rules.yml";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return new YamlRulesParser().Parse(reader);
        }
    }
}
