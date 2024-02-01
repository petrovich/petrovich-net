using System.Threading.Tasks;
using NPetrovich.Rules.Data;

namespace NPetrovich.Rules.Loader
{
    public interface IRulesLoader
    {
        Task<Data.Rules> LoadAsync();
        Task<GenderRules> LoadGenderAsync();
    }
}