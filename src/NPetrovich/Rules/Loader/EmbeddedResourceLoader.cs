using System;
using System.IO;
using System.Reflection;
using NPetrovich.Rules.Data;
using NPetrovich.Rules.Parser.Yaml;
using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Loader
{
    public class EmbeddedResourceLoader : IRulesLoader
    {
        public Data.Rules Load()
        {
            var resourceName = "NPetrovich.rules.yml";
            using (var stream = GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return new YamlRulesParser().Parse(reader);
        }

        private static Stream GetManifestResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        public GenderRules LoadGender()
        {
            var resourceName = "NPetrovich.gender.yml";
            using (var stream = GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
                return new YamlRulesParser().ParseGender(reader);
        }
    }
}
