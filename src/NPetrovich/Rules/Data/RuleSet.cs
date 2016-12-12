using System.Collections.Generic;
using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Data
{
    public class RuleSet
    {
        [YamlAlias("exceptions")]
        public List<Rule> Exceptions { get; set; }

        [YamlAlias("suffixes")]
        public List<Rule> Suffixes { get; set; }
    }

    public class GenderRuleSet
    {
        [YamlAlias("exceptions")]
        public GenderRule Exceptions { get; set; }

        [YamlAlias("suffixes")]
        public GenderRule Suffixes { get; set; }
    }

}
