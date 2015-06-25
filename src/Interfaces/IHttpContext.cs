using System;
using System.Collections;
using System.Security.Principal;

namespace HttpContextAlike.Interfaces
{
    public interface IHttpContext
    {
        DateTime Timestamp { get; }
        IHttpRequest Request { get; }
        IHttpResponse Response { get; }
        IDictionary Items { get; }
        IPrincipal User { get; }
        object Inner { get; }
    }
}