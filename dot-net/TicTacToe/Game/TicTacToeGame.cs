using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    public class TicTacToeGame 
        : IGame
    {
        private readonly IBoard _board;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly IGameJudge _gameJudge;
        private readonly IGameRenderer _gameRenderer;
        private IPlayer _lastPlayerToPlay;

        public TicTacToeGame(
            IBoard board,
            IPlayer player1,
            IPlayer player2,
            IGameJudge gameJudge,
            IGameRenderer gameRenderer
            )
        {
            _board = board;
            _player1 = player1;
            _player2 = player2;
            _gameJudge = gameJudge;
            _gameRenderer = gameRenderer;
        }

        public void Play()
        {
            _board.Reset();
            _gameRenderer.RenderStart(_player1, _player2, _board);

            while (_gameJudge.IsGameInPlay(_board))
            {
                var player = GetNextPlayer();

                player.TakeTurn(_board);

                _lastPlayerToPlay = player;
                _gameRenderer.RenderBoard(_board);
            }

            var result = _gameJudge.GetGameResult(_board, _player1, _player2);

            _gameRenderer.RenderResult(result);
        }

        private IPlayer GetNextPlayer()
        {
            return _lastPlayerToPlay == _player1 
                ? _player2 
                : _player1;
        }
    }
}
