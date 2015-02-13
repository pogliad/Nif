namespace Nif.Core
{
    public interface ICommand<in TContext>
    {
        void Execute(TContext context);
    }
}