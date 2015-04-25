using System;
using System.Collections.Generic;
using mudz.Core.Model.Domain.Environment.Map;
using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Npc;
using mudz.Core.Model.Domain.Player;
using mudz.Core.Model.Domain.Player.Inventory.Item.Weapon;
using mudz.Core.Model.Domain.Player.Inventory.Item.Wearable;

namespace mudz.Core.Model.Domain.GameEngine
{
    public class HiveMind
    {
        public HiveMind()
        {
            World = new Grid()
            {
                Rooms = new Dictionary<RoomKey, RoomContent>(),
                Sheet = new int[10][]
            };

            ResponseStack = new Stack<GameResponse>();

            SeedWorld();
        }

        public Stack<GameResponse> ResponseStack { get; set; } 

        public Grid World { get; set; }

        public GameResponse Execute(GameRequest request)
        {
            var actionType = request.GameAction;
            var sender = request.Sender;
            var target = request.Target;
            GameResponse response;

            switch(actionType)
            {
                case GameActions.Heal:
                    response = sender.Execute(request);
                    target.RestoreHealth(response.Amount);
                    break;
                case GameActions.Fight:
                    response = sender.Execute(request);
                    target.TakeDamage(response.Amount);
                    break;
                case GameActions.Repair:
                    response = sender.Execute(request);
                   throw new NotImplementedException("The repair request has not been implemented.");
                case GameActions.Negotiate:
                    throw new NotImplementedException("The negotiate request has not been implemented.");
                default:
                    throw new NotImplementedException("The action requested is not available!");
            }

            ResponseStack.Push(response);

            return response;
        }


        private void SeedWorld()
        {
            var roomKey = new RoomKey(1, 1);

            World.Rooms.Add(roomKey, new RoomContent(roomKey) { GameObjects = new List<IGameObject>() });

            var room = World.Rooms[roomKey];

            room.Title =
                "Test Chamber";
            room.Description =
                "The room is white with ripples of color rising up from a grey floor to form walls. When you focus on the color it seems to fade. You think you hear voices coming from the other side of the opaque walls but can't be certain.";

            room.GameObjects.Add(PlayerFactory.Create("Gary", ActorGenderTypes.Male, PlayerTypes.Carpenter));
            room.GameObjects.Add(PlayerFactory.Create("Beth", ActorGenderTypes.Female, PlayerTypes.ArmyVet));
            room.GameObjects.Add(NpcFactory.Create("Morgan", NpcTypes.TownsPerson));
            room.GameObjects.Add(NpcFactory.Create("SlowDraw", NpcTypes.Deputy));
            room.GameObjects.Add(MonsterFactory.Create(MonsterTypes.Zombie));
            room.GameObjects.Add(new TestHammer());
            room.GameObjects.Add(new TestGloves());
        }
    }
}
