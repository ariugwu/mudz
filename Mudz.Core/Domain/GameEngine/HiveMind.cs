using System.Collections.Generic;
using System.Linq;
using Mudz.Common.Domain;
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
using Mudz.Data.Domain.Environment.Model;
using Mudz.Data.Domain.GameEngine;
using Mudz.Data.Domain.Localization.Template;

namespace Mudz.Core.Domain.GameEngine
{
    public class HiveMind
    {
        private static readonly HiveMind _hiveMind = new HiveMind();

        static HiveMind()
        {
            var dependencyHandler = new DependencyHandler();
            var authHandler = new AuthHandler();
            var noTargetCommandHandler = new NoTargetCommandHandler();
            var targetCommandHandler = new TargetCommandHandler();
            var itemCommandHandler = new ItemCommandHandler();
            var finalizeHandler = new FinalizeHandler();

            dependencyHandler.SetSuccessor(authHandler);
            authHandler.SetSuccessor(noTargetCommandHandler);
            noTargetCommandHandler.SetSuccessor(itemCommandHandler);
            itemCommandHandler.SetSuccessor(targetCommandHandler);
            targetCommandHandler.SetSuccessor(finalizeHandler);

            _requestHandler = dependencyHandler;

        }

        private HiveMind()
        {
            PlayerMessage = new PlayerMessage();
            TargetMessage = new TargetMessage();
            RoomMessage = new RoomMessage();
        }

        public GameMessage PlayerMessage { get; set; }
        public GameMessage TargetMessage { get; set; }
        public GameMessage RoomMessage { get; set; }

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

        public IActionContext ActionContext { get; set; }

        private Grid _world;

        public Grid World
        {
            get
            {
                if (_world != null) return _world;

                SeedWorld();

                return _world;
            }

            set { _world = value; }
        }

        public GameResponse Execute(GameRequest request)
        {
            ActionContext = new ActionContext
            {
                GameRequest = request,
                ActionItems = new List<IActionResult>()
            };

            // Send the action context through the chain of responsibility. NOTE: We don't need to do a 'var thing = thisReturnsThing(thing)' we are intriniscally passing by reference here.
            _requestHandler.Process(ActionContext);

            // Get a response based on the action context
            var response = BuildResponseFromContext(ActionContext);

            // Build our response.
            ResponseStack.Push(response);

            return response;
        }

        private GameResponse BuildResponseFromContext(IActionContext actionContext)
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
            World = Data.Domain.Environment.EnvironmentRepository.GetSeedGrid();

            var room = World.Rooms.First().Value;

            room.GameObjects.Add(PlayerFactory.Create("Gary", ActorGenderType.Male, PlayerTypes.Carpenter));
            room.GameObjects.Add(PlayerFactory.Create("Beth", ActorGenderType.Female, PlayerTypes.ArmyVet));
            room.GameObjects.Add(NpcFactory.Create("Morgan", NpcTypes.TownsPerson));
            room.GameObjects.Add(NpcFactory.Create("SlowDraw", NpcTypes.Deputy));
            room.GameObjects.Add(MonsterFactory.Create(MonsterTypes.Zombie));
            room.GameObjects.Add(new TestHammer());
            room.GameObjects.Add(new TestGloves());
            room.GameObjects.Add(new TestCharm());
        }
    }
}
