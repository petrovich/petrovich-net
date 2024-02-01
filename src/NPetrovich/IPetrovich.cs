namespace NPetrovich
{
    public interface IPetrovich : IFio
    { 
        bool AutoDetectGender { get; set; }
        Gender Gender { get; set; }
        Petrovich InflectTo(Case @case);
        string InflectFirstNameTo(Case @case);
        string InflectLastNameTo(Case @case);
        string InflectMiddleNameTo(Case @case);
        string ToString();
    }
}
