using System.Collections.Generic;
using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Data
{
    internal class Rule
    {
        [YamlAlias("gender")]
        public string Gender { get; set; }

        [YamlAlias("test")]
        public List<string> TestSuffixes { get; set; }

        [YamlAlias("mods")]
        public List<string> ModSuffixes { get; set; }

        [YamlAlias("tags")]
        public List<string> Tags { get; set; }
    }
}
