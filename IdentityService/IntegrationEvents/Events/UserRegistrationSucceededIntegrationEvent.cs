using System;
using HexMaster.BuildingBlocks.EventBus.Events;

namespace HexMaster.Parcheesi.IdentityService.IntegrationEvents.Events
{
    public class UserRegistrationSucceededIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; private set; }

        public string DisplayName { get; private set; }

        public UserRegistrationSucceededIntegrationEvent(Guid userId, string name)
        {
            UserId = userId;
            DisplayName = name;
        }
    }
}
