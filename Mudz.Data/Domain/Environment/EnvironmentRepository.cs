using System.Collections.Generic;
using Mudz.Common.Domain;
using Mudz.Data.Domain.Environment.Model;

namespace Mudz.Data.Domain.Environment
{
    public static class EnvironmentRepository
    {
        public static Grid GetSeedGrid()
        {
            var grid = new Grid()
                {
                    Rooms = new RoomCollection(),
                    Sheet = new int[10][]
                };

            var roomKey = new RoomKey(1, 1);

            grid.Rooms.Add(roomKey, new RoomContent(roomKey) { GameObjects = new List<IGameObject>() });

            var room = grid.Rooms[roomKey];

            room.Title =
                "Test Chamber";
            room.Description =
                "The room is white with ripples of color rising up from a grey floor to form walls. When you focus on the color it seems to fade. You think you hear voices coming from the other side of the opaque walls but can't be certain.";

            return grid;
        }
    }
}
