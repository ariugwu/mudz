using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Parse;
using mudz.Cli.Domain.GameEngine;
using mudz.Core.Model.Domain.GameEngine;

namespace mudz.Cli.Domain.easytcp
{
    public class ParseStrategy : IParseStrategy
    {
        public Request Parse(string command)
        {
            var commandParser = new CommandParser();

            GameRequest gameRequest = new GameRequest();

            string[] args = command.Split(' ');

            GameActions gameAction = commandParser.GetGameAction(args[0]);

            gameRequest = new GameRequest() {GameAction = gameAction, Target = args[1]};

            return new Request() {Payload = gameRequest, Type = typeof (GameRequest)};
        }
    }
}
