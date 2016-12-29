using System.IO;
using System.Reflection;
using NPetrovich.Rules.Data;
using NPetrovich.Rules.Parser.Json;
using NPetrovich.Rules.Parser.Yaml;

namespace NPetrovich.Rules.Loader
{
    public class EmbeddedResourceLoader : IRulesLoader
    {

        public Data.Rules LoadYaml()
        {
            var resourceName = "NPetrovich.rules.yml";
            using (var stream = GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return new YamlRulesParser().Parse(reader);
        }

        public Data.Rules LoadJson()
        {
            var resourceName = "NPetrovich.rules.json";
            using (var stream = GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return new JsonRulesParser().Parse(reader);
        }

        public Data.Rules Load()
        {
            return LoadYaml();
        }

        private static Stream GetManifestResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }
        
        public GenderRules LoadGenderYaml()
        {
            var resourceName = "NPetrovich.gender.yml";
            using (var stream = GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return new YamlRulesParser().ParseGender(reader);
        }

        public GenderRules LoadGenderJson()
        {
            var resourceName = "NPetrovich.gender.json";
            using (var stream = GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return new JsonRulesParser().ParseGender(reader);
        }

        public GenderRules LoadGender()
        {
            return LoadGenderYaml();
        }
    }
}
