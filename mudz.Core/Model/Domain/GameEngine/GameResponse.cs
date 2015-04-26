namespace mudz.Core.Model.Domain.GameEngine
{
    public class GameResponse
    {
        public GameRequest Request { get; set; }
        public string Message { get; set; }
        public double Amount { get; set; }
    }
}
