namespace Nif.Patterns.CQS
{
    public interface IQuery<in TQuestion, out TAnswer>
    {
        TAnswer Ask(TQuestion question);
    }
}