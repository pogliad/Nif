namespace Nif.Extensions
{
    public static class NullableExtensions
    {
        public static bool IsNotNull<TSource>(this TSource source) where TSource : class
        {
            return !ReferenceEquals(source, null);
        }

        public static bool IsNull<TSource>(this TSource source) where TSource : class
        {
            return ReferenceEquals(source, null);
        }
    }
}