using NPetrovich.Rules.Loader;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures;

[TestFixture]
public class RulesFixture
{
    [Test]
    public void Rules_json_should_be_valid_json_file()
    {
        EmbeddedResourceLoader loader = new EmbeddedResourceLoader();

        Assert.DoesNotThrowAsync(async () => await loader.LoadJsonAsync());
    }

    [Test]
    public void GenderRules_json_should_be_valid_json_file()
    {
        EmbeddedResourceLoader loader = new EmbeddedResourceLoader();

        Assert.DoesNotThrowAsync(async () => await loader.LoadGenderJsonAsync());
    }
}