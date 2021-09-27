using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReportService
{
    public class ReportDataCollector : IHostedService
    {
        int DEFAULT_COUNT = 100;
        private readonly ISubscriber _subscriber;
        private readonly IMemoryReportStorage _memoryReportStorage;


        public ReportDataCollector(ISubscriber subscriber, IMemoryReportStorage memoryReportStorage)
        {
            _subscriber = subscriber;
            _memoryReportStorage = memoryReportStorage;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Subscribe(ProcessMessage);
            return Task.CompletedTask;
        }

        private bool ProcessMessage(string message, IDictionary<string, object> headers)
        {
            var platform = JsonConvert.DeserializeObject<Plateform>(message);
            if (_memoryReportStorage.Get().Any(r => r.Name == platform.Name))
            {
                _memoryReportStorage.Get().First(r => r.Name == platform.Name).Count--;
            }
            else
            {
                _memoryReportStorage.Add(new Report
                {
                    Name = platform.Name,
                    Count = DEFAULT_COUNT - 1
                });
            }
            return true;
        }   



        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
