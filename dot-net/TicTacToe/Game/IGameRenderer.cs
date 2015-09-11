namespace TicTacToe.Game
{
    public interface IGameRenderer
    {
        void RenderResult(IGameResult gameResult);
        void RenderBoard(IBoard board);
        void RenderStart(IPlayer player1, IPlayer player2, IBoard board);
    }
}