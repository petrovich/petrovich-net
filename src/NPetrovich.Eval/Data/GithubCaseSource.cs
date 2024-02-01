using System.Diagnostics;
using Timer = NPetrovich.Eval.Helper.Timer;

namespace NPetrovich.Eval.Data;

class GithubCaseSource : ICaseSource
{
    private const string PetrovichEvalMaster = "https://raw.githubusercontent.com/petrovich/petrovich-eval/master/";
        
    public void Load()
    {
        LastNames = Load("surnames.tsv");
        FirstNames = Load("firstnames.tsv");
        MiddleNames = Load("midnames.tsv");
    }

    private IEvalCase[] Load(string fileName)
    {
        using HttpClient client = new HttpClient();
        var timer = new Timer();
        var res = CaseLoader.LoadCase(client.GetStreamAsync(PetrovichEvalMaster+fileName).Result);
        Debug.WriteLine($"Загружен файл {fileName} за {timer}");
        return res;
    }

    public IEvalCase[] LastNames { get; private set; }
    public IEvalCase[] FirstNames { get; private set; }
    public IEvalCase[] MiddleNames { get; private set; }
}