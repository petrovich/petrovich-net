using NPetrovich.GenderDetermination;
using NPetrovich.Inflection;
using NPetrovich.Rules;
using NPetrovich.Rules.Loader;
using NPetrovich.Utils;

namespace NPetrovich
{
    public class Petrovich : IFio
    {
        private readonly RulesProvider _provider;
        private readonly GenderDeterminator _genderDeterminator;
        private static readonly RulesProvider EmbeddedResourceLoader = new RulesProvider(new EmbeddedResourceLoader());

        public Petrovich(IRulesLoader rulesLoader = null)
        {
            var loader = rulesLoader;
            _provider = loader != null? new RulesProvider(loader): EmbeddedResourceLoader;
            _genderDeterminator = rulesLoader == null ? GenderUtils.Determinator : new GenderDeterminator(_provider);
        }

        public virtual bool AutoDetectGender { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }

        public virtual Petrovich InflectTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(FirstName, "FirstName", "First name was not provided");
            Guard.IfArgumentNullOrWhitespace(LastName, "LastName", "Last name was not provided");
            Guard.IfArgumentNullOrWhitespace(MiddleName, "MiddleName", "Middle name was not provided");

            var inflected = new Petrovich();

            if (AutoDetectGender) DetectGender();

            var inflection = new CaseInflection(_provider, Gender);

            inflected.FirstName = inflection.InflectFirstNameTo(FirstName, @case);
            inflected.LastName = inflection.InflectLastNameTo(LastName, @case);
            inflected.MiddleName = inflection.InflectMiddleNameTo(MiddleName, @case);

            return inflected;
        }

        public virtual string InflectFirstNameTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(FirstName, "FirstName", "First name was not provided");

            if (AutoDetectGender) DetectGender();

            return FirstName = new CaseInflection(_provider, Gender).InflectFirstNameTo(FirstName, @case);
        }

        public virtual string InflectLastNameTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(LastName, "LastName", "Last name was not provided");

            if (AutoDetectGender) DetectGender();

            return LastName = new CaseInflection(_provider, Gender).InflectLastNameTo(LastName, @case);
        }

        public virtual string InflectMiddleNameTo(Case @case)
        {
            Guard.IfArgumentNullOrWhitespace(MiddleName, "MiddleName", "Middle name was not provided");

            if (AutoDetectGender) DetectGender();

            return MiddleName = new CaseInflection(_provider, Gender).InflectMiddleNameTo(MiddleName, @case);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }

        protected virtual void DetectGender()
        {
            if (Gender == Gender.Androgynous)
                Gender = _genderDeterminator.Determinate(this);
        }
    }
}
