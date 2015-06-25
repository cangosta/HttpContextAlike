using System.Net.Http;

namespace HttpContextAlike
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