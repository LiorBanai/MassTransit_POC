using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Tests
{
    public interface ISystemEventConsumer
    {
        event EventHandler<SystemEvent> OnNewSystemEvent;
    }
}
