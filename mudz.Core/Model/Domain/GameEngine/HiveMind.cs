using System;
using System.Collections.Generic;
using mudz.Core.Model.Domain.Environment.Map;
using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.Inventory;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Npc;
using mudz.Core.Model.Domain.Player;
using mudz.Core.Model.Domain.Player.Inventory.Item.Keepsake;
using mudz.Core.Model.Domain.Player.Inventory.Item.Weapon;
using mudz.Core.Model.Domain.Player.Inventory.Item.Wearable;

namespace mudz.Core.Model.Domain.GameEngine
{
    public class HiveMind
    {
        private static readonly HiveMind _hiveMind = new HiveMind();

        static HiveMind()
        {
            
        }

        private HiveMind()
        {
        }


        public static HiveMind Instance
        {
            get { return _hiveMind; }
        }

        private Stack<GameResponse> _responseStack;

        public Stack<GameResponse> ResponseStack
        {
            get { return _responseStack ?? (_responseStack = new Stack<GameResponse>()); }
        }


        private Grid _world;

        public Grid World
        {
            get
            {
                if (_world != null) return _world;

                _world = new Grid()
                {
                    Rooms = new Dictionary<RoomKey, RoomContent>(),
                    Sheet = new int[10][]
                };

                SeedWorld();

                return _world;
            }
        }

        public GameResponse Execute(GameRequest request)
        {
            var actionType = request.GameAction;
            var sender = request.Sender;
            var target = request.Target;

            GameResponse response;

            if (IsOutOfPlay(sender)) return OutOfPlayResponse(request, sender);
            if (IsOutOfPlay(target)) return OutOfPlayResponse(request, target);

            if (!IsTargetPresent(request.RoomKey, target)) return NoTargetResponse(request, target);

            switch(actionType)
            {
                case GameActions.Heal:
                    response = sender.ExecuteAction(request);
                    if (response.WasSuccessful) target.RestoreHealth(response.Amount);
                    break;
                case GameActions.Fight:
                    response = sender.ExecuteAction(request);
                    if (response.WasSuccessful) target.TakeDamage(response.Amount);
                    break;
                case GameActions.Repair:
                    response = sender.ExecuteAction(request);
                    if (response.WasSuccessful) target.Repair();
                    break;
                case GameActions.Negotiate:
                    response = sender.ExecuteAction(request);
                    if (response.WasSuccessful) target.Negotiate();
                    break;
                case GameActions.Look:
                    response = new GameResponse(){ Message = target.Description, WasSuccessful = true, Request = request};
                    break;
                case GameActions.Get:
                    if (target.GameObjectType != GameObjectTypes.InventoryItem)
                    {
                        response = InvalidTargetResponse(request, target);
                        break;
                    }

                    var item = (IInventoryItem)World.Rooms[request.RoomKey].GetGameObject(target.GameObjectKey);
                    response = sender.ProcessItem(item);

                    if (response.WasSuccessful) World.Rooms[request.RoomKey].GameObjects.Remove(item);

                    break;
                default:
                    throw new NotImplementedException("The action requested is not available!");
            }

            sender.CheckState();
            target.CheckState();

            response.Request = request;
            ResponseStack.Push(response);

            return response;
        }


        private bool IsOutOfPlay(IGameObject gameObject)
        {
            return (gameObject.GameObjectState == GameObjectStates.OutOfPlay);
        }

        private bool IsTargetPresent(RoomKey roomKey, IGameObject gameObject)
        {
            return World.Rooms[roomKey].GameObjects.Exists(x => x.GameObjectKey == gameObject.GameObjectKey);
        }

        private GameResponse OutOfPlayResponse(GameRequest request, IGameObject gameObject)
        {
            return new GameResponse()
            {
                Request = request,
                WasSuccessful = false,
                Message = String.Format("Sorry, {0} is out of play!", gameObject.Name)
            };
        }

        private GameResponse NoTargetResponse(GameRequest request, IGameObject gameObject)
        {
            return new GameResponse()
            {
                Request = request,
                WasSuccessful = false,
                Message = String.Format("Sorry, there doesn't seem to be '{0}' here.", gameObject.Name)
            };
        }

        private GameResponse InvalidTargetResponse(GameRequest request, IGameObject gameObject)
        {
            return new GameResponse()
            {
                Request = request,
                WasSuccessful = false,
                Message = String.Format("That doesn't make any sense. '{0}' is not a valid target for this command.", gameObject.Name)
            };
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
            room.GameObjects.Add(new TestCharm());
        }
    }
}
