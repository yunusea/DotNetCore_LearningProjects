using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestResponseMiddleware> logger;

        public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            //Request

            //Original httpContext Request Body Stream Backup
            var OriginalBodyStream = httpContext.Response.Body;

            //Request QueryString Log
            logger.LogInformation($"Request QueryString: {httpContext.Request.QueryString}");

            //Create a new MemoryStream
            MemoryStream RequestBody = new MemoryStream();

            //Copying HttpContext Request Body to MemoryStream
            await httpContext.Request.Body.CopyToAsync(RequestBody);

            //Go to first line
            RequestBody.Seek(0, SeekOrigin.Begin);

            //Read copy request body
            string RequestText = await new StreamReader(RequestBody).ReadToEndAsync();

            //Go to first line again
            RequestBody.Seek(0, SeekOrigin.Begin);

            
            var TempStream = new MemoryStream();
            httpContext.Response.Body = TempStream;


            await next.Invoke(httpContext); // In Progress

            //Response

            //Go to the first line to read httpContext Response Body
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

            //Read to Response Body
            string ResponseText = await new StreamReader(httpContext.Response.Body, Encoding.UTF8).ReadToEndAsync();

            //Go to first line again
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

            //Load to original response body
            await httpContext.Response.Body.CopyToAsync(OriginalBodyStream);

            //Add Request And Response Logging
            logger.LogInformation($"Request: {RequestText}");
            logger.LogInformation($"Response: {ResponseText}");
        }
    }
}
