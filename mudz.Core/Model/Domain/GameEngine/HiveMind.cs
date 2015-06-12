using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Common.Domain;
using mudz.Common.Domain.Environment.Map;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;
using mudz.Common.Domain.Monster;
using mudz.Common.Domain.Npc;
using mudz.Common.Domain.Player;
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

            if (request.GameAction != GameActions.Login)
            {
                if (IsOutOfPlay(sender)) return OutOfPlayResponse(request, sender);
                if (IsOutOfPlay(target)) return OutOfPlayResponse(request, target);

                if (!IsTargetPresent(request.RoomKey, target)) return NoTargetResponse(request, target);
            }

            switch(actionType)
            {
                case GameActions.Login:
                    var player = GetPlayerByName(sender.Name);

                    if (player == null)
                    {
                        response = new GameResponse(){ Message = "Sorry. No Player by that name!", WasSuccessful = false, Request = request};
                    }
                    else
                    {
                        var room = GetRoomByPlayerName(sender.Name);
                        response = new GameResponse(){ Player = (IPlayer)player, WasSuccessful = true, RoomContent = room,Request = request};
                    }
                    
                    break;
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
                case GameActions.LookAt:
                    response = new GameResponse(){ Message = target.Description, WasSuccessful = true, Request = request};
                    break;
                case GameActions.LookAround:
                    response = new GameResponse() { Message = String.Format("{0} looks around.", sender.Name), WasSuccessful = false, Request = request };
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
                case GameActions.None:
                    response = new GameResponse()
                    {
                        Message = "Sorry, no command matched your request.",
                        WasSuccessful = false,
                        Request = new GameRequest() { GameAction = GameActions.None, Sender = sender, Target = null }
                    };

                    break;
                default:
                    throw new NotImplementedException("The action requested is not available!");
            }

            if (request.GameAction != GameActions.Login)
            {
                sender.CheckState();
                target.CheckState();

                response.Request = request;
            }

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

        private IGameObject GetPlayerByName(string playerName)
        {
            var room = GetRoomByPlayerName(playerName);
            var player = (room != null)? room.GameObjects.First(x => x.Name.ToLower().Equals(playerName.ToLower())) : null;

            return player;
        }

        private RoomContent GetRoomByPlayerName(string playerName)
        {
            return HiveMind.Instance.World.Rooms.FirstOrDefault(x => x.Value.GameObjects.Exists(y => y.Name.ToLower().Equals(playerName.ToLower()))).Value;
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
