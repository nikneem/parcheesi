using HexMaster.BuildingBlocks.EventBus.Events;

namespace HexMaster.Parcheesi.IdentityService.Contracts.Events
{
    public interface IIdentityIntegrationEventService
    {
            //Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
            void PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}