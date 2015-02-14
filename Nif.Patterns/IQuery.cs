namespace Nif.Patterns
{
    public interface IQuery<in TQuestion, out TAnswer>
    {
        TAnswer Ask(TQuestion question);
    }
}