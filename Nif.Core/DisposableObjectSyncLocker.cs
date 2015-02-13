namespace Nif.Core
{
    public abstract class DisposableObjectSyncLocker : Disposable
    {
        protected static readonly object Locker = new object();
    }
}