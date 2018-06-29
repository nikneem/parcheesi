using System;
using System.Collections.Generic;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.GameService.DomainModels
{
    public class Player : DomainModelBase<Guid>
    {
        public User User { get; set; }
        public List<Pawn> Pawns { get; set; }
        public int Sequence { get; set; }

    }
}
