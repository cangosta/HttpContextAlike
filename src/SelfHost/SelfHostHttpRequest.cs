using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace HttpContextAlike.SelfHost
{
    public class SelfHostHttpRequest : IHttpRequest
    {
        public SelfHostHttpRequest(HttpRequestMessage request)
        {
            Inner = request;
        }

        public object Inner { get; private set; }
    }
}