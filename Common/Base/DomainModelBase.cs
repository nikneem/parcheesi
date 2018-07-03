using HexMaster.Parcheesi.Common.Infrastructure.Enums;

namespace HexMaster.Parcheesi.Common.Base
{
    public abstract class DomainModelBase <TId> : TrackingStateBase
    {

        public TId Id { get; set; }



        protected DomainModelBase() :
            base(TrackingState.Added)
        {
        }

        protected DomainModelBase(TId id, TrackingState state = TrackingState.Unchanged): base(state)
        {
            Id = id;
        }

    }
}
