namespace NPetrovich.Eval.Data;

public interface IEvalCase
{
    string Lemma { get; }
    string Word { get; }
    Gender Gender { get; }
    Case Case { get; }
    string Result { get; set; }
}