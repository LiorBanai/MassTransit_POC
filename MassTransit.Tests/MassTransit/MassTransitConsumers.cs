using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MassTransit;
using MassTransit.Tests;
using Microsoft.Extensions.Logging;

namespace PipeBaseServices.MassTransit
{
   
    public class MTSystemEventConsumer : IConsumer<SystemEvent>, ISystemEventConsumer
    {
        public event EventHandler<SystemEvent> OnNewSystemEvent;
        private ILogger<MTSystemEventConsumer> logger;

        public MTSystemEventConsumer(ILogger<MTSystemEventConsumer> logger = null)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<SystemEvent> context)
        {
            OnNewSystemEvent?.Invoke(this, context.Message);
            return Task.CompletedTask;
        }
    }
}
