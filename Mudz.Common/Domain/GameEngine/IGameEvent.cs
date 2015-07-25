namespace Mudz.Common.Domain.GameEngine
{
    public interface IGameEvent
    {
        IGameRequest GameRequest { get; set; }
        IGameResponse GameResponse { get; set; }
    }
}