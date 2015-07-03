using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Parse;
using mudz.Cli.Domain.Player;
using mudz.Common.Domain.easytcp;

namespace mudz.Cli.Domain.easytcp
{
    public class ParseStrategy : IParseStrategy
    {
        public string CommandPrompt()
        {
            if (PlayerOne.Instance == null)
            {
                System.Console.WriteLine("Please type your name to login: ");
                System.Console.Write("> ");
                return System.Console.ReadLine();
            }

            return System.Console.ReadLine();
        }

        public Request Parse(string command)
        {
            ConsoleRequest consoleRequest;

            if (PlayerOne.Instance == null)
            {
                PlayerOne.Instance = new Core.Domain.Player.Player(){ Name = command};

                consoleRequest = new ConsoleRequest() { Command = command, PlayerName = null };
                return new Request() { Payload = consoleRequest, Type = typeof(ConsoleRequest) };
            }
            else
            {
                consoleRequest = new ConsoleRequest() { Command = command, PlayerName = PlayerOne.Instance.GetName() };
                return new Request() { Payload = consoleRequest, Type = typeof(ConsoleRequest) };
            }

        }
    }
}
