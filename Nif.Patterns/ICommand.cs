namespace Nif.Patterns
{
    public interface ICommand<in TContext>
    {
        void Execute(TContext context);
    }
}