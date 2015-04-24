using System;
using Nif.Core;

namespace Nif.Tests.Common
{
    public class TestTimeProvider : TimeProvider
    {
        private readonly DateTime _customDateTime;

        public TestTimeProvider(DateTime customDateTime)
        {
            _customDateTime = customDateTime;
        }

        public override DateTime UtcNow
        {
            get { return _customDateTime; }
        }
    }
}