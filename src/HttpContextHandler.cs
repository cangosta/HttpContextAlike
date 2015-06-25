using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HttpContextAlike.Implementations;

namespace HttpContextAlike
{
    public class HttpContextHandler : DelegatingHandler
    {
        
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           
            HttpContext.Current = new HttpContext(request); 
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var result = task.Result;
                
                ((HttpContext)HttpContext.Current).SetResponse(result);
                
                return result;
            });
        }
    }
}

