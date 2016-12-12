using System.Collections.Generic;
using System.Linq;
using NPetrovich.Rules;
using NPetrovich.Rules.Data;
using NPetrovich.Rules.Loader;
using NPetrovich.Utils;

namespace NPetrovich.GenderDetermination
{
    public class GenderDeterminator
    {
        private readonly RuleSetDeterminator _firstNameDet;
        private readonly RuleSetDeterminator _lastNameDet;
        private readonly RuleSetDeterminator _middleNameDet;

        internal GenderDeterminator(RulesProvider rulesLoader = null)
        {
            var genderRules = (rulesLoader ?? new RulesProvider(new EmbeddedResourceLoader())).GenderRules;
            _lastNameDet = new RuleSetDeterminator(genderRules.LastName);
            _firstNameDet = new RuleSetDeterminator(genderRules.FirstName);
            _middleNameDet = new RuleSetDeterminator(genderRules.MiddleName);
        }

        private DetectedGender DetectForParts(IFio petrovich)
        {
            return new DetectedGender
            {
                FirstName = _firstNameDet.Determinate(WordPreparer.GetChunks(petrovich.FirstName?.Trim())),
                LastName = _lastNameDet.Determinate(WordPreparer.GetChunks(petrovich.LastName?.Trim())),
                MiddleName = _middleNameDet.Determinate(WordPreparer.GetChunks(petrovich.MiddleName?.Trim()))
            };
        }

        public Gender Determinate(IFio petrovich)
        {
            return DetectForParts(petrovich).Result;
        }

        private class DetectedGender
        {
            public Gender LastName { get; set; }
            public Gender MiddleName { get; set; }
            public Gender FirstName { get; set; }

            private Gender[] NotMiddleName => new[] {FirstName, LastName};

            public Gender Result
            {
                get
                {
                    //Отчество первично
                    if (MiddleName != Gender.Androgynous)
                        return MiddleName;
                    if (NotMiddleName.Where(x => x != Gender.Androgynous).Distinct().Count() > 1)
                        return Gender.Androgynous;
                    return NotMiddleName.FirstOrDefault(x => x != Gender.Androgynous);
                }
            }
        }

        private class RuleMatcher
        {
            private readonly Dictionary<Gender, SuffixMatching> _matchers;

            public RuleMatcher(GenderRule rule, bool wholeWord)
            {
                _matchers = new Dictionary<Gender, SuffixMatching>
                {
                    {Gender.Androgynous, new SuffixMatching(rule?.Androgynous, wholeWord)},
                    {Gender.Male, new SuffixMatching(rule?.Male, wholeWord)},
                    {Gender.Female, new SuffixMatching(rule?.Female, wholeWord)}
                };
            }

            public Gender? IsMatched(string chunk)
            {
                var candidates = _matchers.Where(x => x.Value.IsMatched(chunk)).ToArray();
                return candidates.Length != 1 ? (Gender?) null : candidates[0].Key;
            }
        }

        private class RuleSetDeterminator
        {
            private readonly RuleMatcher _exceptionsMathcer;
            private readonly RuleMatcher _suffixMathcer;

            public RuleSetDeterminator(GenderRuleSet ruleSet)
            {
                _exceptionsMathcer = new RuleMatcher(ruleSet?.Exceptions, true);
                _suffixMathcer = new RuleMatcher(ruleSet?.Suffixes, false);
            }

            public Gender Determinate(IEnumerable<string> chunks)
            {
                if (!chunks.Any())
                    return Gender.Androgynous;
                var value = chunks.Select(_exceptionsMathcer.IsMatched).LastOrDefault(x => x.HasValue);
                if (value.HasValue) return value.Value;
                value = chunks.Select(_suffixMathcer.IsMatched).LastOrDefault(x => x.HasValue);
                return value ?? Gender.Androgynous;
            }
        }
    }
}