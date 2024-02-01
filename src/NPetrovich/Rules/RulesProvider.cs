using NPetrovich.Rules.Loader;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly:InternalsVisibleTo("NPetrovich.Tests")]
namespace NPetrovich.Rules
{
    
    internal class RulesProvider
    {
        private readonly Lazy<Data.Rules> _rules;
        private readonly Lazy<Data.GenderRules> _genderRules;

        public Data.Rules Rules => _rules.Value;

        public Data.GenderRules GenderRules => _genderRules.Value;

        public RulesProvider(IRulesLoader loader)
        {
            _rules = new Lazy<Data.Rules>(() => loader.LoadAsync().Result, LazyThreadSafetyMode.ExecutionAndPublication);
            _genderRules = new Lazy<Data.GenderRules>(() => loader.LoadGenderAsync().Result, LazyThreadSafetyMode.ExecutionAndPublication);
        }
    }
}
