using System;

namespace Nif.Core.Utilities
{
    public static class NewKeyUtility
    {
        public static string GetNewKey()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}