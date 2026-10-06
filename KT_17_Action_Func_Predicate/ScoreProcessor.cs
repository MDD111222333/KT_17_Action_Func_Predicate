using System;

namespace Delegates_ScoreProcessing
{
    public class ScoreProcessor
    {
        public void PrintScore(int score)
        {
            Console.WriteLine($"Очки: {score}");
        }

        public int ApplyBonus(int score)
        {
            return score + 10;
        }

        public bool IsPassing(int score)
        {
            return score >= 60;
        }
    }
}