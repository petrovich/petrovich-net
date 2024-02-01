using NPetrovich.Eval.Data;

namespace NPetrovich.Eval.Evaluation;

public interface IEvaluateParameters
{
    string Description { get; }
    Action<Petrovich, string> PetrovichAccessor { get; }
    Func<ICaseSource, IEvalCase[]> CaseAccessor { get; }
}