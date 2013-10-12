using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Data
{
    public class Rules
    {
        [YamlAlias("lastname")]
        public RuleSet LastName { get; set; }

        [YamlAlias("firstname")]
        public RuleSet FirstName { get; set; }

        [YamlAlias("middlename")]
        public RuleSet MiddleName { get; set; }
    }
}
