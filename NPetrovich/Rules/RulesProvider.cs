using System;
using System.Threading;
using NPetrovich.Rules.Loader;

namespace NPetrovich.Rules
{
    internal class RulesProvider
    {
        private readonly Lazy<Data.Rules> rules;

        private readonly IRulesLoader loader;

        public Data.Rules Rules { get { return rules.Value; } }

        public RulesProvider(IRulesLoader loader)
        {
            this.loader = loader;

            rules = new Lazy<Data.Rules>(loader.Load, LazyThreadSafetyMode.ExecutionAndPublication);
        }


    }
}
