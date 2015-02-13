namespace Nif.Core
{
    public interface IFactory<out T>
    {
        T Create(object context);
    }
}