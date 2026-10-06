using System;
using System.Collections.Generic;

namespace Delegates_ScoreProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> scores = new List<int>();

            Console.WriteLine("Введите очки игроков через пробел:");

            try
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new Exception("Строка ввода не должна быть пустой.");
                }

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    scores.Add(int.Parse(part));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: разрешено вводить только целые числа.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
                return;
            }

            ScoreProcessor processor = new ScoreProcessor();

            Action<int> printScore = processor.PrintScore;
            Func<int, int> applyBonus = processor.ApplyBonus;
            Predicate<int> isPassingPredicate = processor.IsPassing;
            Func<int, bool> isPassingFunc = processor.IsPassing;

            Console.WriteLine();
            foreach (int score in scores)
            {
                printScore(score);
            }

            Console.WriteLine();
            if (scores.Count > 0)
            {
                Console.WriteLine($"applyBonus({scores[0]}): {applyBonus(scores[0])}");
            }

            Console.WriteLine();
            int passingScore = scores.Find(isPassingPredicate);
            Console.WriteLine($"scores.Find(isPassing): {passingScore}");
        }
    }
}