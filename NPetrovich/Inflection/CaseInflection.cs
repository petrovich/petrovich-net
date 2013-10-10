using System;
using System.Collections.Generic;
using System.Linq;
using NPetrovich.Rules;
using NPetrovich.Rules.Data;

namespace NPetrovich.Inflection
{
    internal class CaseInflection
    {
        private readonly RulesProvider provider;
        private readonly Gender gender;

        public CaseInflection(RulesProvider provider, Gender gender)
        {
            this.provider = provider;
            this.gender = gender;
        }

        public string InflectFirstNameTo(string firstName, Case @case)
        {
            return InflectTo(firstName, @case, provider.Rules.FirstName);
        }

        public string InflectLastNameTo(string lastName, Case @case)
        {
            return InflectTo(lastName, @case, provider.Rules.LastName);
        }

        public string InflectMiddleNameTo(string middleName, Case @case)
        {
            return InflectTo(middleName, @case, provider.Rules.MiddleName);
        }

        private string InflectTo(string name, Case @case, RuleSet ruleSet)
        {
            var nameChunks = name.Split('-').ToList();

            return string.Join("-", nameChunks.Select((chunk, index) =>
                {
                    bool firstWord = index == 0 && nameChunks.Count > 1;
                    return FindAndApply(chunk, @case, ruleSet, new Dictionary<string, bool> { { "first_word", firstWord } });
                }));
        }

        private string FindAndApply(string name, Case @case, RuleSet ruleSet, Dictionary<string, bool> features)
        {
            Rule rule = FindRulesFor(name, ruleSet, features);

            if (rule == null)
                return name;

            return Apply(name, @case, rule);
        }

        private string Apply(string name, Case @case, Rule rule)
        {
            foreach (var @char in FindCaseModificator(@case, rule))
            {
                switch (@char)
                {
                    case '.':
                        break;
                    case '-':
                        name = name.Substring(0, name.Length - 1);
                        break;
                    default:
                        name += @char;
                        break;
                }
            }
                
            return name;
        }

        private string FindCaseModificator(Case @case, Rule rule)
        {
            switch (@case)
            {
                case Case.Nominative:
                    return ".";
                case Case.Genitive:
                    return rule.ModSuffixes[0];
                case Case.Dative:
                    return rule.ModSuffixes[1];
                case Case.Accusative:
                    return rule.ModSuffixes[2];
                case Case.Instrumental:
                    return rule.ModSuffixes[3];
                case Case.Prepositional:
                    return rule.ModSuffixes[4];
                default:
                    throw new NotSupportedException(string.Format("Unknown grammatical case: {0}", @case));
            }
        }

        private Rule FindRulesFor(string name, RuleSet ruleSet, Dictionary<string, bool> features)
        {
            HashSet<string> tags = ExtractTags(features);

            Rule rule;
            if (ruleSet.Exceptions != null)
            {
                rule = Find(name, ruleSet.Exceptions, true, tags);
                if (rule != null)
                    return rule;
            }

            return Find(name, ruleSet.Suffixes, false, tags);
        }

        private HashSet<string> ExtractTags(Dictionary<string, bool> features)
        {
            return new HashSet<string>(features.Where(f => f.Value).Select(f => f.Key));
        }

        private Rule Find(string name, List<Rule> rules, bool matchWholeWord, HashSet<string> tags)
        {
            return rules.FirstOrDefault(rule => MatchRule(name, rule, matchWholeWord, tags));
        }

        private bool MatchRule(string name, Rule rule, bool matchWholeWord, HashSet<string> tags)
        {
            if ((rule.Tags ?? new List<string>()).Except(tags).Any())
                return false;

            Gender genderRule;
            if (Enum.TryParse(rule.Gender, true, out genderRule) &&
                ((genderRule == Gender.Male && gender == Gender.Female) ||
                 (genderRule == Gender.Female && gender != Gender.Female)))
            {
                return false;
            }

            name = name.ToLower();
            foreach (var chars in rule.TestSuffixes)
            {
                string test = matchWholeWord ? name : name.Substring(new []{0, name.Length - chars.Length}.Max());
                if (test.Equals(chars))
                    return true;
            }

            return false;
        }
    }
}
