using System.Diagnostics;
using NPetrovich.Eval.Data;
using NPetrovich.Eval.Evaluation;

namespace NPetrovich.Eval
{
    internal class Program
    {
        private static GithubCaseSource _source;

        private static void Main(string[] args)
        {
            Prepare();
            var evaluator = new Evaluator(_source);
            evaluator.Evaluate(new EvaluateParameters
            {
                Description = "Имена",
                CaseAccessor = x => x.FirstNames,
                PetrovichAccessor = (x, y) => x.FirstName = y,
                PetrovichInflectAccessor = (x, y) => x.InflectFirstNameTo(y)
            });
            evaluator.Evaluate(new EvaluateParameters
            {
                Description = "Фамилии",
                CaseAccessor = x => x.LastNames,
                PetrovichAccessor = (x, y) => x.LastName = y,
                PetrovichInflectAccessor = (x, y) => x.InflectLastNameTo(y)
            });
            evaluator.Evaluate(new EvaluateParameters
            {
                Description = "Отчества",
                CaseAccessor = x => x.MiddleNames,
                PetrovichAccessor = (x, y) => x.MiddleName = y,
                PetrovichInflectAccessor = (x, y) => x.InflectMiddleNameTo(y)
            });
        }

        private static void Prepare()
        {
            Debug.Listeners.Add(new ConsoleTraceListener());
            _source = new GithubCaseSource();
            _source.Load();
        }
    }
}