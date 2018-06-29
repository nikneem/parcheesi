using System;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.GameService.DomainModels
{
    public class BoardSpot : DomainModelBase<Guid>
    {

        public int Position { get; set; }

    }
}