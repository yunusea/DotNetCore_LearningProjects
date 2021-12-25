using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        //RequestDelegate bir request oluştuğunda request'e ait bütün bilgilerin tutulduğu bir obje. Kontrolü .NET Core tarafından yapılıyor.
        public ExceptionHandlerMiddleware(RequestDelegate Next, ILogger<ExceptionHandlerMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Middleware'imiz StartUp dosyasından projeye Middleware olarak tanıtıldığı için gelen request ilgili controller'a düşmek yerine önce yazdığımız middlerware'e
            //girecek ve middleware içerisinde ki Invoke metodu tetiklenecek.

            //Ne zaman next'in yani RequestDelegate'in Invoke metodu tetiklenirse uygulama kaldığı yerden çalışmaya devam eder.
            //await next.Invoke(httpContext);

            try
            {
                //Akışda buraya giriyor try bloğu içerisinde normal akışa devam ediyor. 
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                //Hata Yönetimi...
                logger.LogError(ex.Message);
            }

        }
    }
}
