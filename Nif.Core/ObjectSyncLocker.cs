namespace Nif.Core
{
    public abstract class ObjectSyncLocker
    {
        protected static readonly object Locker = new object();
    }
}