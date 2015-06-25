using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HttpContextAlike.SelfHost;

namespace HttpContextAlike
{
    public class HttpContextHandler : DelegatingHandler
    {
        private const string HttpContextProperty = "MS_HttpContext";
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           
            HttpContext.Current = new SelfHostHttpContext(request); 
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var result = task.Result;
                
                ((SelfHostHttpContext)HttpContext.Current).SetResponse(result);
                
                return result;
            });
        }
    }
}

