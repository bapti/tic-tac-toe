using System;
using System.Threading;

namespace TicTacToe.Game.Utils
{
    public interface IGamePauser
    {
        void Pause();
    }

    public class GamePauser : IGamePauser
    {
        private readonly TimeSpan _pauseTime;

        public GamePauser(TimeSpan pauseTime)
        {
            _pauseTime = pauseTime;
        }

        public void Pause()
        {
            Thread.Sleep(_pauseTime);
        }
    }
}