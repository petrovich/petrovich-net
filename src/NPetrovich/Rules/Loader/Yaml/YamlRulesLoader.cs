using System.IO;
using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Loader.Yaml
{
    public class YamlRulesLoader : IRulesLoader
    {
        private readonly string path;

        public YamlRulesLoader(string path)
        {
            this.path = path;
        }

        public Data.Rules Load()
        {
            using (StreamReader reader = new StreamReader(path, true))
            {
                return new Deserializer().Deserialize<Data.Rules>(reader);
            }
        }
    }
}
