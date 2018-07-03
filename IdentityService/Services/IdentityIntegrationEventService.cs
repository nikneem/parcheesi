using System;
using System.Threading.Tasks;
using HexMaster.BuildingBlocks.EventBus.Abstractions;
using HexMaster.BuildingBlocks.EventBus.Events;
using HexMaster.Parcheesi.IdentityService.Contracts.Events;

namespace HexMaster.Parcheesi.IdentityService.Services
{
    public class IdentityIntegrationEventService: IIdentityIntegrationEventService
    {

        private readonly IEventBus _eventBus;

        public IdentityIntegrationEventService(IEventBus eventBus )
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public void PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            _eventBus.Publish(evt);

//            await _eventLogService.MarkEventAsPublishedAsync(evt);
        }

    }
}
