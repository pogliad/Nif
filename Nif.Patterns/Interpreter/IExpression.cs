namespace Nif.Patterns.Interpreter
{
    public interface IExpression<T>
    {
        void Interpret(Context<T> context);
    }
}