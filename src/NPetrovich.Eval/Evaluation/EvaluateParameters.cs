using System;
using NPetrovich.Eval.Data;

namespace NPetrovich.Eval.Evaluation
{
    public class EvaluateParameters : IEvaluateParameters
    {
        public string Description { get; set; }
        public Action<Petrovich, string> PetrovichAccessor { get; set; }
        public Func<Petrovich, Case, string> PetrovichInflectAccessor { get; set; }
        public Func<ICaseSource, IEvalCase[]> CaseAccessor { get; set; }
    }
}