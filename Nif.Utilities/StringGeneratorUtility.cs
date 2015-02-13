using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Nif.Utilities
{
    public abstract class CharsProviderBase
    {
        public abstract string Chars { get; }
    }

    public class DefaultCharsProvider : CharsProviderBase
    {
        public override string Chars { get { return "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; } }
    }

    public static class StringGeneratorUtility
    {
        public static string Generate<T>(int length) where T : CharsProviderBase
        {
            Contract.Requires<ArgumentOutOfRangeException>(length >= 0);

            var random = new Random();
            var charsProvider = (CharsProviderBase)Activator.CreateInstance(typeof(T));

            return new string(
                Enumerable.Repeat(charsProvider.Chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }
    }
}