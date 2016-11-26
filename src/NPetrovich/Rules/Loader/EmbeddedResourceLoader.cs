using System;
using System.IO;
using System.Reflection;
using NPetrovich.Rules.Parser;
using NPetrovich.Rules.Parser.Json;
using NPetrovich.Rules.Parser.Yaml;

namespace NPetrovich.Rules.Loader
{
    public class EmbeddedResourceLoader : IRulesLoader
    {
        public Data.Rules LoadYaml()
        {
            return Load("NPetrovich.rules.yml", new YamlRulesParser());
        }

        public Data.Rules LoadJson()
        {
            return Load("NPetrovich.rules.json", new JsonRulesParser());
        }

        public Data.Rules Load()
        {
            return LoadYaml();
        }

        public Data.Rules Load(string resourceName, IRulesParser parser)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new IOException(String.Format("Couldn't load embedded resource \"{0}\"", resourceName));

                using (var reader = new StreamReader(stream))
                {
                    return parser.Parse(reader);
                }
            }
        }
    }
}
