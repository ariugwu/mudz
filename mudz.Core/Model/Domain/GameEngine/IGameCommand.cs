namespace mudz.Core.Model.Domain.GameEngine
{
    public interface IGameCommand
    {
        GameResponse Execute(GameRequest request);
        void CheckState();
    }
}
