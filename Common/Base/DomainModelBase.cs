using HexMaster.Parcheesi.Common.Infrastructure.Enums;

namespace HexMaster.Parcheesi.Common.Base
{
    public abstract class DomainModelBase <TId>
    {

        public TId Id { get; set; }

        public TrackingState TrackingState { get; private set; } = TrackingState.Unchanged;

        protected virtual void SetState(TrackingState state)
        {
            switch (state)
            {
                case TrackingState.Added:
                    TrackingState = state;
                    break;
                case TrackingState.Modified:
                case TrackingState.Deleted:
                    if (TrackingState == TrackingState.Unchanged ||
                        TrackingState == TrackingState.Touched ||
                        TrackingState == TrackingState.Modified)
                    {
                        TrackingState = state;
                    }
                    break;
                case TrackingState.Touched:
                    if (TrackingState == TrackingState.Unchanged)
                    {
                        TrackingState = state;
                    }
                    break;
            }
        }

        protected DomainModelBase()
        {
            TrackingState = TrackingState.Added;
        }

        protected DomainModelBase(TId id)
        {
            Id = id;
        }

    }
}
