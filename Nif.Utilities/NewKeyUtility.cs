using System;

namespace Nif.Utilities
{
    public static class NewKeyUtility
    {
        public static string GetNewKey()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}