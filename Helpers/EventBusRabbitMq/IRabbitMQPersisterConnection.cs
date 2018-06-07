using System;
using RabbitMQ.Client;

namespace HexMaster.BuildingBlocks.EventBus.RabbitMq
{
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
