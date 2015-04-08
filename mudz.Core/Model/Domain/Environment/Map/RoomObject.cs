using System;

namespace mudz.Core.Model.Domain.Environment.Map
{
    public class RoomObject
    {
        public Type DerivedType { get; set; }
        public IGameObject GameObject { get; set; }
    }
}
