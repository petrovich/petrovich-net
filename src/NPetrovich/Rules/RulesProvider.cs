using NPetrovich.Rules.Loader;
using System;
using System.Threading;

namespace NPetrovich.Rules
{
    internal class RulesProvider
    {
        private readonly Lazy<Data.Rules> rules;
        private readonly Lazy<Data.GenderRules> genderRules;
        private readonly IRulesLoader loader;

        public Data.Rules Rules { get { return rules.Value; } }

        public Data.GenderRules GenderRules { get { return genderRules.Value; } }

        public RulesProvider(IRulesLoader loader)
        {
            this.loader = loader;

            rules = new Lazy<Data.Rules>(loader.Load, LazyThreadSafetyMode.ExecutionAndPublication);
            genderRules = new Lazy<Data.GenderRules>(loader.LoadGender, LazyThreadSafetyMode.ExecutionAndPublication);
        }
    }
}
