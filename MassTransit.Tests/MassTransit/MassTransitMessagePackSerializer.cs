using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MessagePack;

namespace PipeBaseServices.MassTransit
{
    public class MassTransitMessagePackSerializer : IMessageSerializer
    {
        public ContentType ContentType { get; } = new ContentType("application/msgpack");

        public MessageBody GetMessageBody<T>(SendContext<T> context) where T : class
        {

            var data = MessagePackSerializer.Serialize(context.Message);
            return new BytesMessageBody(data);
        }

    }
}
