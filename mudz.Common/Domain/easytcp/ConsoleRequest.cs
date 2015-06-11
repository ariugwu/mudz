using System;

namespace mudz.Common.Domain.easytcp
{
    [Serializable]
    public class ConsoleRequest
    {
        public string PlayerName { get; set; }
        public string Command { get; set; }
    }
}
