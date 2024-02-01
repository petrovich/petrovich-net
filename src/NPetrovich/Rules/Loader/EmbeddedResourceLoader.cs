using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using NPetrovich.Rules.Data;
using NPetrovich.Rules.Parser.Json;

namespace NPetrovich.Rules.Loader
{
    public class EmbeddedResourceLoader : IRulesLoader
    {
        public async Task<Data.Rules> LoadJsonAsync()
        {
            var resourceName = "NPetrovich.rules.json";
            using (var stream = GetManifestResourceStream(resourceName))
                return await new JsonRulesParser().ParseAsync(stream);
        }

        public async Task<Data.Rules> LoadAsync()
        {
            return await LoadJsonAsync();
        }

        private static Stream GetManifestResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }
        
        public async Task<GenderRules> LoadGenderJsonAsync()
        {
            var resourceName = "NPetrovich.gender.json";
            using (var stream = GetManifestResourceStream(resourceName))
                return await new JsonRulesParser().ParseGenderAsync(stream);
        }

        public async Task<GenderRules> LoadGenderAsync()
        {
            return await LoadGenderJsonAsync();
        }
    }
}
