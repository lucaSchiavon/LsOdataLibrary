using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Ls.Base.WebApi
{
    public class LsInternalServerError : IHttpActionResult
    {
        public string Message { get; set; }
        public Exception ex { get; set; }
        public HttpStatusCode status { get; set; }
        public ApiController controller { get; }

        public LsInternalServerError(ApiController cont, string message)
        {
            status = HttpStatusCode.InternalServerError;
            this.controller = cont;
            this.Message = message;
        }

        public LsInternalServerError(ApiController cont, string message, Exception ex)
        {
            status = HttpStatusCode.InternalServerError;
            this.controller = cont;
            this.Message = message;
            this.ex = ex;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage respMsg = new HttpResponseMessage()
            {
                StatusCode = status,
                ReasonPhrase = Message,
                Content = new StringContent(String.Concat(ex.Message, ex.InnerException.Message))
            };

            return await Task.Run(() => respMsg);
        }
    }
}
