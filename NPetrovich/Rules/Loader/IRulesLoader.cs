using System.IO;

namespace NPetrovich.Rules.Loader
{
    internal interface IRulesLoader
    {
        Data.Rules Load();
    }
}