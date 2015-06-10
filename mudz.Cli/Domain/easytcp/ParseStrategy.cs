using easyTcp.Common.Model;
using easyTcp.Common.Model.Client.Parse;
using mudz.Common.Domain.easytcp;

namespace mudz.Cli.Domain.easytcp
{
    public class ParseStrategy : IParseStrategy
    {
        public string CommandPrompt()
        {
            throw new System.NotImplementedException();
        }

        public Request Parse(string command)
        {
            ConsoleRequest consoleRequest = new ConsoleRequest(){ Command = command, PlayerName = null};

            return new Request() {Payload = consoleRequest, Type = typeof (ConsoleRequest)};
        }
    }
}
