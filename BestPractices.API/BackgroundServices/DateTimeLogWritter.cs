using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BestPractices.API.BackgroundServices
{
    //Implementing BackgroundService Abstract Class, another method to create Background Services
    public class DateTimeLogWriterNewType : BackgroundService
    {
        //if you can want to do override
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        //if you can want to do override
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        //Operations to apply on Background Services
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }

    //Implementing IHostedService Interface for Class to be Background Services
    public class DateTimeLogWritter : IHostedService, IDisposable
    {
        private Timer timer;
        //Start Background Service
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{typeof(DateTimeLogWritter)} Service Stared...");

            timer = new Timer(WriteDateTimeOnLog, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            //while (!cancellationToken.IsCancellationRequested)
            //{
            //    WriteDateTimeOnLog();
            //    await Task.Delay(1000);
            //}

            return Task.CompletedTask;
        }

        private void WriteDateTimeOnLog(object state)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}");
        }

        //Stop Background Service
        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            Console.WriteLine($"{typeof(DateTimeLogWritter)} Service Stopped...");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer = null;
        }
    }
}
