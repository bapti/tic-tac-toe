using System;

namespace TicTacToe.Game.Utils
{
    public interface IRandomNumberPicker
    {
        int Pick(int min, int max);
    }

    public class RandomNumberPicker
        : IRandomNumberPicker
    {
        private readonly Random _random;

        public RandomNumberPicker()
        {
            _random = new Random(Guid.NewGuid().GetHashCode());
        } 

        public int Pick(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
