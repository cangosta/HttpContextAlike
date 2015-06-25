using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Threading;

namespace HttpContextAlike
{
    public abstract class HttpContext : IHttpContext
    {
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
        public static IHttpContext Current
        {
            get
            {
                try
                {
                    Lock.EnterReadLock();
                    return ResolveContext();
                }
                finally
                {
                    Lock.ExitReadLock();
                }
            }
            set
            {
                try
                {
                    Lock.EnterWriteLock();
                    SaveContext(value);
                }
                finally
                {
                    Lock.ExitWriteLock();                    
                }
            }
        }

        private static IHttpContext ResolveContext()
        {
            return CallContext.LogicalGetData("ctx") as IHttpContext;
        }

        private static void SaveContext(IHttpContext value)
        {
            CallContext.LogicalSetData("ctx", value);
        }

        public DateTime Timestamp { get; protected set; }
        public IHttpRequest Request { get; protected set; }
        public IHttpResponse Response { get; protected set; }
        public IDictionary Items { get; protected set; }
        public IPrincipal User { get; protected set; }
        public object Inner { get; protected set; }
    }
}