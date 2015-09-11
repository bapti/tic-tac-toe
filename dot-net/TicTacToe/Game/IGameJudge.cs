namespace TicTacToe.Game
{
    public interface IGameJudge
    {
        bool IsGameInPlay(IBoard board);
        IGameResult GetGameResult(IBoard board, IPlayer player1, IPlayer player2);
    }
}