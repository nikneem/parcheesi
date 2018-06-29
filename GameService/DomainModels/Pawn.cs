using System;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.GameService.DomainModels
{
    public class Pawn : DomainModelBase<Guid>
    {
        public Guid? Position { get; set; }
        public bool IsHome { get; set; }
        public bool IsFinished { get; set; }
    }
}