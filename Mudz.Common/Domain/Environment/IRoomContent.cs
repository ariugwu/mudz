using System;
using System.Collections.Generic;

namespace Mudz.Common.Domain.Environment
{
    public interface IRoomContent
    {
        IRoomKey RoomKey { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        List<IGameObject> GameObjects { get; set; }
        IGameObject GetGameObject(Guid guid);
    }
}