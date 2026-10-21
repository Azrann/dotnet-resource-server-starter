using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;

namespace ResourceServer.Api.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ResponseMessageResult ResponseMessage<T>(HttpStatusCode httpStatusCode, T result) where T : class
        {
            return ResponseMessage(new HttpResponseMessage(httpStatusCode)
                                       {
                                           Content = new StringContent(JsonConvert.SerializeObject(result))
                                       });
        }
    }
}