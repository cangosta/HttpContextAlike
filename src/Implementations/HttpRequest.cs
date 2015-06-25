using HttpContextAlike.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace HttpContextAlike.Implementations
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(HttpRequestMessage request)
        {
            Inner = request;
        }

        public object Inner { get; private set; }
    }
}