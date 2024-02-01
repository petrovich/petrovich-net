namespace NPetrovich.Eval.Data;

public interface ICaseSource
{
    IEvalCase[] LastNames { get; }
    IEvalCase[] FirstNames { get; }
    IEvalCase[] MiddleNames { get; }
}