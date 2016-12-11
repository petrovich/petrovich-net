
using NPetrovich.Rules.Data;

namespace NPetrovich.Rules.Loader
{
    public interface IRulesLoader
    {
        Data.Rules Load();
        GenderRules LoadGender();
    }
}