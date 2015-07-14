using System.Collections.Generic;
using Mudz.Common.Domain;
using Mudz.Common.Domain.Environment.Map;
using Mudz.Common.Domain.Environment.Map.Room;
using Mudz.Common.Domain.GameEngine;
using Mudz.Common.Domain.Monster;
using Mudz.Common.Domain.Npc;
using Mudz.Common.Domain.Player;
using Mudz.Core.Domain.GameEngine.Handler;
using Mudz.Core.Domain.Monster;
using Mudz.Core.Domain.Npc;
using Mudz.Core.Domain.Player;
using Mudz.Core.Domain.Player.Inventory.Item.Keepsake;
using Mudz.Core.Domain.Player.Inventory.Item.Weapon;
using Mudz.Core.Domain.Player.Inventory.Item.Wearable;

namespace Mudz.Core.Domain.GameEngine
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
                GameRequest = request,
                ActionItems = new List<ActionResult>()
            };

            // Send the action context through the chain of responsibility.
            actionContext = _requestHandler.Process(actionContext);

            // Get a response based on the action context
            var response = BuildResponseFromContext(actionContext);

            // Build our response.
            ResponseStack.Push(response);

            return response;
        }

        private GameResponse BuildResponseFromContext(ActionContext actionContext)
        {
            return new GameResponse()
            {
                CurrentAction = actionContext.GameRequest.GameAction,
                ActionItems = actionContext.ActionItems,
                RoomContent = actionContext.Room,
                RequestByPlayerName = actionContext.GameRequest.PlayerName
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
