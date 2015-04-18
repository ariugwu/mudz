namespace mudz.Core.Model.Domain.GameEngine
{
    public class GameRequest
    {
        public EventTypes EventType { get; set; }
        public string TextResource { get; set; }
        public IGameObject Sender { get; set; }
        public IGameObject Target { get; set; }
    }
}
