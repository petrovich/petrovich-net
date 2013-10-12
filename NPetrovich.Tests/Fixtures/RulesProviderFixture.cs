using Moq;
using NPetrovich.Rules;
using NPetrovich.Rules.Loader;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures
{
    [TestFixture]
    public class RulesProviderFixture
    {
        [Test]
        public void Should_automatically_load_rules()
        {
            var loader = new Mock<IRulesLoader>();
            loader.Setup(l => l.Load()).Returns(new Rules.Data.Rules());

            var provider = new RulesProvider(loader.Object);
            var rules = provider.Rules;

            loader.Verify(l => l.Load(), Times.AtLeastOnce);
        }        
        
        [Test]
        public void Should_load_rules_only_once()
        {
            var loader = new Mock<IRulesLoader>();
            loader.Setup(l => l.Load()).Returns(new Rules.Data.Rules());

            var provider = new RulesProvider(loader.Object);
            var rules = provider.Rules;
            var rules2 = provider.Rules;

            loader.Verify(l => l.Load(), Times.Exactly(1));
        }
    }
}
