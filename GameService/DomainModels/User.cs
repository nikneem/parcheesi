using System;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.GameService.DomainModels
{
    public class User : DomainModelBase<Guid>
    {
        public string Name { get; set; }
    }
}