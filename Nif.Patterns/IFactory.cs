namespace Nif.Patterns
{
    public interface IFactory<out T>
    {
        T Create(object context);
    }
}