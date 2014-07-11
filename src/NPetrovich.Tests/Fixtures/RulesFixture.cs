using NPetrovich.Rules.Loader;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures
{
    [TestFixture]
    public class RulesFixture
    {
        [Test]
        public void Rules_yml_should_be_valid_yaml_file()
        {
            EmbeddedResourceLoader loader = new EmbeddedResourceLoader();

            Assert.DoesNotThrow(() => loader.Load());
        }
    }
}
