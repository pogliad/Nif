namespace Nif.Patterns.Interpreter
{
    public class Context<T>
    {
        public T Input { get; set; }
        public T Output { get; set; }
    }
}