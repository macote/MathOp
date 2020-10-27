namespace Mathop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Mathop.Lib;

    class Program
    {
        static void Main(string[] args)
        {
            var history = new HashSet<string>();
            Func<int, int, bool> rule1 = (v1, v2) =>
            {
                var sorted = string.Join("", new int[] { v1, v2 }.OrderBy(v => v).Select(v => v.ToString()));
                if (history.Contains(sorted))
                {
                    return false;
                }

                history.Add(sorted);

                return true;
            };
            var test = TestFactory.CreateTest2(
                new Operation(Operation.OperationType.Multiply),
                2, 7,
                2, 11,
                rule1,
                20
                );

            Console.WriteLine("Press ENTER to start.");
            Console.ReadLine();

            test.Start();
            Console.WriteLine("Test started.");
            Console.WriteLine();
            int answerCount = 0, correctAnswerCount = 0;
            foreach (var equation in test)
            {
                ++answerCount;
                Console.Write(equation.ToString() + " : ");
                if (int.TryParse(Console.ReadLine(), out var intAnswer) && equation.TrySolve(intAnswer))
                {
                    ++correctAnswerCount;
                    Console.WriteLine("Bonne réponse!");
                    //Console.WriteLine("Good answer!");
                }
                else
                {
                    Console.Write("Mauvaise réponse...");
                    var correctAnswer = equation.Solve();
                    if (correctAnswer.HasValue)
                    {
                        Console.Write("  La réponse était " + correctAnswer.Value);
                    }
                    
                    Console.WriteLine();
                    //Console.WriteLine("Bad answer...");
                }
            }

            test.Stop();
            Console.WriteLine();
            Console.WriteLine(string.Format($"Durée du test : {(double)test.EllapsedMilliseconds / 1000} seconde(s)"));
            Console.Write(string.Format($"Résultat du test : {correctAnswerCount} bonne(s) réponse(s) sur {answerCount}"));
            if (correctAnswerCount == answerCount)
            {
                Console.Write(" => G é n i a l !");
            }
            else if (correctAnswerCount / (double)answerCount >= 0.95)
            {
                Console.Write(" => S u p e r !");
            }
            else if (correctAnswerCount / (double)answerCount >= 0.90)
            {
                Console.Write(" => B r a v o !");
            }
            else
            {
                Console.Write(" => L â c h e   p a s !");
            }

            Console.WriteLine();
            var correctAnswerSpeed = Math.Round(correctAnswerCount * 60 / ((double)test.EllapsedMilliseconds / 1000), 2);
            Console.WriteLine(string.Format($"Vitesse : {correctAnswerSpeed} bonnes réponses par minute"));
            Console.WriteLine();
            Console.WriteLine("Test stopped.");
            Console.WriteLine();

            Console.WriteLine("Press ENTER to terminate.");
            Console.ReadLine();
        }
    }
}