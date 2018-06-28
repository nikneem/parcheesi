using System;
using System.Collections.Generic;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.GameService.DomainModels
{
    public class Game : DomainModelBase<Guid>
    {

        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<BoardSpot> BoardSpots { get; set; }
        public GameState State { get; set; }

    }
}
