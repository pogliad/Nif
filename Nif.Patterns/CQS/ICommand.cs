namespace Nif.Patterns.CQS
{
    public interface ICommand<in TContext>
    {
        void Execute(TContext context);
    }
}