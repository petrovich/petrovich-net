using NPetrovich.Rules.Loader.Yaml;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures
{
    [TestFixture]
    public class RulesFixture
    {
        [Test]
        public void Rules_yml_should_be_valid_yaml_file()
        {
            YamlRulesLoader loader = new YamlRulesLoader("rules.yml");

            Assert.DoesNotThrow(() => loader.Load());
        }
    }
}
