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

        protected DomainModelBase(TId id)
        {
            Id = id;
        }

    }
}
