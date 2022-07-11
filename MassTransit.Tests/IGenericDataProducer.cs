using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Tests
{
    public interface IGenericDataProducer<T>
    {
        event EventHandler<string> OnErrorOccurredOnPipe;
        void InitWithAcq();
        Task PublishAsync(T frame);
        void Publish(T frame);
        void ClosePipe();
    }
}
