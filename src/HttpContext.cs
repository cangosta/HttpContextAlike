using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Threading;
using System.Net.Http;

namespace HttpContextAlike
{
    public sealed class HttpContext : IHttpContext
    {
        private const string HttpContextProperty = "MS_HttpContext";

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
            return CallContext.LogicalGetData(HttpContextProperty) as IHttpContext;
        }

        private static void SaveContext(IHttpContext value)
        {
            CallContext.LogicalSetData(HttpContextProperty, value);
        }

        public DateTime Timestamp { get; protected set; }
        public IHttpRequest Request { get; protected set; }
        public IHttpResponse Response { get; protected set; }
        public IDictionary Items { get; protected set; }
        public IPrincipal User { get; protected set; }
        public object Inner { get; protected set; }

        public HttpContext()
        {
            Timestamp = DateTime.Now;
            Items = new ConcurrentDictionary<string, object>();
            User = Thread.CurrentPrincipal;
            Inner = this;
        }

        public HttpContext(HttpRequestMessage request) : this()
        {
            Request = new HttpRequest(request);
            //request.Properties.Add("MS_HttpContext", this);
        }

        public void SetResponse(HttpResponseMessage response)
        {
            Response = new HttpResponse(response);
        }
    }
}