using System;

namespace Mudz.Data.Domain.EasyTcp
{
    [Serializable]
    public class ConsoleRequest
    {
        public string PlayerName { get; set; }
        public string Command { get; set; }
    }
}
