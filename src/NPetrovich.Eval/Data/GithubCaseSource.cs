using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using NPetrovich.Eval.Helper;

namespace NPetrovich.Eval.Data
{
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
            using (WebClient client = new WebClient())
            {
                var timer = new Timer();
                var res = CaseLoader.LoadCase(new StreamReader(new MemoryStream(client.DownloadData(PetrovichEvalMaster+fileName)),Encoding.UTF8));
                Debug.WriteLine($"Загружен файл {fileName} за {timer}");
                return res;
            }
        }

        public IEvalCase[] LastNames { get; private set; }
        public IEvalCase[] FirstNames { get; private set; }
        public IEvalCase[] MiddleNames { get; private set; }
    }
}