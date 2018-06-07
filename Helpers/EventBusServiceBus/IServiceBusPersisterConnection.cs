using System;
using Microsoft.Azure.ServiceBus;

namespace HexMaster.BuildingBlocks.EventBus.ServiceBus
{
    public interface IServiceBusPersisterConnection : IDisposable
    {
        ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }

        ITopicClient CreateModel();
    }
}