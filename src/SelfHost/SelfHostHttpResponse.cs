using System.Net.Http;

namespace HttpContextAlike.SelfHost
{
    public class SelfHostHttpResponse : IHttpResponse
    {
        public SelfHostHttpResponse(HttpResponseMessage response)
        {
            Inner = response;
        }

        public object Inner { get; private set; }
    }
}