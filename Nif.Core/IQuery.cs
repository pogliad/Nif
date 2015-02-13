namespace Nif.Core
{
    public interface IQuery<in TQuestion, out TAnswer>
    {
        TAnswer Ask(TQuestion question);
    }
}