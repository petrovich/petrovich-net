using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Data
{
    public class Rules<TItem>
    {
        [YamlAlias("lastname")]
        public TItem LastName { get; set; }

        [YamlAlias("firstname")]
        public TItem FirstName { get; set; }

        [YamlAlias("middlename")]
        public TItem MiddleName { get; set; }
    }


    public class Rules: Rules<RuleSet>
    {
    }

    public class GenderRules : Rules<GenderRuleSet>
    {
    }
}
