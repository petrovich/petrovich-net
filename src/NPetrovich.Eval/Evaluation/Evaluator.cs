using System.Diagnostics;
using NPetrovich.Eval.Data;
using Timer = NPetrovich.Eval.Helper.Timer;

namespace NPetrovich.Eval.Evaluation;

public class Evaluator
{
    private readonly ICaseSource _caseSource;

    public Evaluator(ICaseSource caseSource)
    {
        _caseSource = caseSource;
    }

    public void Evaluate(EvaluateParameters parameters)
    {
        var timer = new Timer();
        var errors = new List<IEvalCase>();
        var caseData = parameters.CaseAccessor(_caseSource);
        int totalGood = 0;
        foreach (var @case in caseData)
        {
            string inflectResult;
            var isActive = EvaluateCase(parameters, @case, out inflectResult);
            @case.Result = inflectResult;
            if (isActive)
                totalGood++;
            else
            {
                errors.Add(@case);
            }
        }
        var rate = (double) totalGood/ caseData.Length;
        Debug.WriteLine("");
        Debug.WriteLine($"Проверен '{parameters.Description}' за {timer} (на 1000 {timer.Duration.TotalSeconds * 1000/ (caseData.Length):R} сек.) точность '{rate}'");
        File.WriteAllLines(parameters.Description+".errors.txt", errors.Select(x=>x.ToString()));
    }

    private static bool EvaluateCase(EvaluateParameters parameters, IEvalCase @case, out string inflectResult)
    {
        var petrovich = new Petrovich
        {
            Gender = @case.Gender
        };
        parameters.PetrovichAccessor(petrovich, @case.Lemma);
        inflectResult = parameters.PetrovichInflectAccessor(petrovich, @case.Case);
        var isActive = inflectResult.ToLower().Equals(@case.Word.ToLower());
        return isActive;
    }
}