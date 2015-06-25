using HttpContextAlike.Interfaces;
using System.Net.Http;

namespace HttpContextAlike.Implementations
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse(HttpResponseMessage response)
        {
            Inner = response;
        }

        public object Inner { get; private set; }
    }
}