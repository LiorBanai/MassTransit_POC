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
    public abstract class MassTransitProducer<T> : IGenericDataProducer<T>
    {
        public ILogger Logger { get; }
        public event EventHandler<string> OnErrorOccurredOnPipe;

        readonly IBus _bus;

        public MassTransitProducer(IBus bus, ILogger logger)
        {
            Logger = logger;
            _bus = bus;
        }
        public void InitWithAcq()
        {
        }

        public async Task PublishAsync(T message)
        {
            try
            {
                await _bus.Publish(message);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "MT Error publish: {e}", e.Message);
                OnErrorOccurredOnPipe?.Invoke(this, $"MT Error publish: {e.Message}");
            }

        }

        public void Publish(T message)
        {
            try
            {
                _bus.Publish(message);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "MT Error publish: {e}", e.Message);
                OnErrorOccurredOnPipe?.Invoke(this, $"MT Error publish: {e.Message}");
            }
        }

        public void ClosePipe()
        {
            //
        }
    }


    public class MTSystemEventProducer : MassTransitProducer<SystemEvent>
    {
        public MTSystemEventProducer(IBus bus, ILogger<MTSystemEventProducer> logger) : base(bus,logger)
        {
        }
    }
}
