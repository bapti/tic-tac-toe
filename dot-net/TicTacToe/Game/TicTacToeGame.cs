using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game.Board;
using TicTacToe.Game.Judge;
using TicTacToe.Game.Player;

namespace TicTacToe.Game
{
    public class TicTacToeGame 
        : IGame
    {
        private readonly ITicTacToeBoard _ticTacToeBoard;
        private readonly ITicTacToePlayer _player1;
        private readonly ITicTacToePlayer _player2;
        private readonly IGameJudge _gameJudge;
        private readonly IGameRenderer _gameRenderer;
        private ITicTacToePlayer _lastTicTacToePlayerToPlay;

        public TicTacToeGame(
            ITicTacToeBoard ticTacToeBoard,
            ITicTacToePlayer player1,
            ITicTacToePlayer player2,
            IGameJudge gameJudge,
            IGameRenderer gameRenderer
            )
        {
            _ticTacToeBoard = ticTacToeBoard;
            _player1 = player1;
            _player2 = player2;
            _gameJudge = gameJudge;
            _gameRenderer = gameRenderer;
        }

        public void Play()
        {
            _ticTacToeBoard.Reset();
            _gameRenderer.RenderStart(_player1, _player2, _ticTacToeBoard);

            while (_gameJudge.IsGameInPlay(_ticTacToeBoard))
            {
                var player = GetNextPlayer();

                player.TakeTurn(_ticTacToeBoard);

                _lastTicTacToePlayerToPlay = player;
                _gameRenderer.RenderBoard(_ticTacToeBoard);
            }

            var result = _gameJudge.GetGameResult(_ticTacToeBoard, _player1, _player2);

            _gameRenderer.RenderResult(result);
        }

        private ITicTacToePlayer GetNextPlayer()
        {
            return _lastTicTacToePlayerToPlay == _player1 
                ? _player2 
                : _player1;
        }
    }
}
