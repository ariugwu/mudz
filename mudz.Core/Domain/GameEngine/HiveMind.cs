using System.Collections.Generic;
using mudz.Common.Domain;
using mudz.Common.Domain.Environment.Map;
using mudz.Common.Domain.Environment.Map.Room;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Monster;
using mudz.Common.Domain.Npc;
using mudz.Common.Domain.Player;
using mudz.Core.Domain.GameEngine.Handler;
using mudz.Core.Domain.Monster;
using mudz.Core.Domain.Npc;
using mudz.Core.Domain.Player;
using mudz.Core.Domain.Player.Inventory.Item.Keepsake;
using mudz.Core.Domain.Player.Inventory.Item.Weapon;
using mudz.Core.Domain.Player.Inventory.Item.Wearable;

namespace mudz.Core.Domain.GameEngine
{
    public class HiveMind
    {
        private static readonly HiveMind _hiveMind = new HiveMind();

        static HiveMind()
        {

            var dependencyHandler = new DependencyHandler();
            var authHandler = new AuthHandler();
            var commandHandler = new CommandHandler();
            var finalizeHandler = new FinalizeHandler();

            dependencyHandler.SetSuccessor(authHandler);
            authHandler.SetSuccessor(commandHandler);
            commandHandler.SetSuccessor(finalizeHandler);

            _requestHandler = dependencyHandler;
        }

        private HiveMind()
        {
        }

        private static BaseHandler _requestHandler;

        public static HiveMind Instance
        {
            get { return _hiveMind; }
        }

        private Stack<GameResponse> _responseStack;

        public Stack<GameResponse> ResponseStack
        {
            get { return _responseStack ?? (_responseStack = new Stack<GameResponse>()); }
        }

        public ActionContext ActionContext { get; set; }

        private Grid _world;

        public Grid World
        {
            get
            {
                if (_world != null) return _world;

                _world = new Grid()
                {
                    Rooms = new RoomCollection(),
                    Sheet = new int[10][]
                };

                SeedWorld();

                return _world;
            }
        }

        public GameResponse Execute(GameRequest request)
        {
            var actionContext = new ActionContext
            {
                CurrentAction = request.GameAction, 
                Player = request.Sender, Target = request.Target, 
                ActionItems = new List<ActionResult>()
            };
                     
            var response = new GameResponse();

            // Send the action context through the chain of responsibility.
            actionContext = _requestHandler.Process(actionContext);

            // Build our response.
            response.CurrentAction = actionContext.CurrentAction;
            response.ActionItems = actionContext.ActionItems;
            response.RoomContent = actionContext.Room;

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
            room.GameObjects.Add(new TestCharm());
        }
    }
}
