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

            Assert.DoesNotThrow(() => loader.LoadYaml());
        }

        [Test]
        public void GenderRules_yml_should_be_valid_yaml_file()
        {
            EmbeddedResourceLoader loader = new EmbeddedResourceLoader();

            Assert.DoesNotThrow(() => loader.LoadGenderYaml());
        }

        [Test]
        public void Rules_json_should_be_valid_json_file()
        {
            EmbeddedResourceLoader loader = new EmbeddedResourceLoader();

            Assert.DoesNotThrow(() => loader.LoadJson());
        }

        [Test]
        public void GenderRules_json_should_be_valid_json_file()
        {
            EmbeddedResourceLoader loader = new EmbeddedResourceLoader();

            Assert.DoesNotThrow(() => loader.LoadGenderJson());
        }
    }
}
