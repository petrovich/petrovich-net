using NPetrovich.Inflection;
using NPetrovich.Rules;
using NPetrovich.Rules.Loader;
using NPetrovich.Rules.Loader.Yaml;
using NPetrovich.Utils;

namespace NPetrovich
{
    public class Petrovich
    {
        public Petrovich()
        {
            loader = new YamlRulesLoader("rules.yml");
            provider = new RulesProvider(loader);
        }

        private readonly IRulesLoader loader;
        private readonly RulesProvider provider;

        public Gender Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public Petrovich InflectTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(FirstName, "FirstName", "First name was not provided");
            Guard.IfArgumentNullOrWhitespace(LastName, "LastName", "Last name was not provided");
            Guard.IfArgumentNullOrWhitespace(MiddleName, "MiddleName", "Middle name was not provided");

            var inflection = new CaseInflection(provider, Gender);

            FirstName = inflection.InflectFirstNameTo(FirstName, @case);
            LastName = inflection.InflectLastNameTo(LastName, @case);
            MiddleName = inflection.InflectMiddleNameTo(MiddleName, @case);

            return this;
        }

        public string InflectFirstNameTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(FirstName, "FirstName", "First name was not provided");
            return FirstName = new CaseInflection(provider, Gender).InflectFirstNameTo(FirstName, @case);
        }

        public string InflectLastNameTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(LastName, "FirstName", "Last name was not provided");
            return LastName = new CaseInflection(provider, Gender).InflectLastNameTo(LastName, @case);
        }

        public string InflectMiddleNameTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(MiddleName, "FirstName", "Middle name was not provided");
            return MiddleName = new CaseInflection(provider, Gender).InflectMiddleNameTo(MiddleName, @case);
        }

        public void DetectGender()
        {
            Gender = GenderUtils.Detect(MiddleName);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", LastName, FirstName, MiddleName);
        }
    }
}
