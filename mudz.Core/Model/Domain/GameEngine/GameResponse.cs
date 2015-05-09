namespace mudz.Core.Model.Domain.GameEngine
{
    public class GameResponse
    {
        public GameRequest Request { get; set; }

        public bool WasSuccessful { get; set; }

        public string Message { get; set; }
        public int Amount { get; set; }
    }
}
