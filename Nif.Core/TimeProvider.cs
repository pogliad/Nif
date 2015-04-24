using System;
using Nif.Core.Extensions;

namespace Nif.Core
{
    public abstract class TimeProvider
    {
        private static TimeProvider _current;
        public static TimeProvider Current
        {
            get { return _current; }
            set
            {
                if (value.IsNull())
                {
                    throw new ArgumentNullException("value");
                }

                _current = value;
            }
        }

        public abstract DateTime UtcNow { get; }

        static TimeProvider()
        {
            _current = new DefaultTimeProvider();
        }

        public static void ResetToDefault()
        {
            _current = new DefaultTimeProvider();
        }
    }

    public class DefaultTimeProvider : TimeProvider
    {
        public override DateTime UtcNow { get { return DateTime.UtcNow; } }
    }
}