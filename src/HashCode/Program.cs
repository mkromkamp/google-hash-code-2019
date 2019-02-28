using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLines1 = File.ReadAllLines($"input/sample1.in").ToArray();
            var challenge1 = Input.Parse(inputLines1);
            Output.Write(challenge1.SolveSimpleWithFirstOpt(), $"output/sample1.out");

            var inputLines2 = File.ReadAllLines($"input/sample2.in").ToArray();
            var challenge2 = Input.Parse(inputLines2);
            Output.Write(challenge2.SolveSimpleWithFirstOpt(), $"output/sample2.out");

            var inputLines3 = File.ReadAllLines($"input/sample3.in").ToArray();
            var challenge3 = Input.Parse(inputLines3);
            Output.Write(challenge3.SolveSimpleWithFirstOpt(), $"output/sample3.out");

            var inputLines4 = File.ReadAllLines($"input/sample4.in").ToArray();
            var challenge4 = Input.Parse(inputLines4);
            Output.Write(challenge4.SolveSimpleWithFirstOpt(), $"output/sample4.out");

            var inputLines5 = File.ReadAllLines($"input/sample5.in").ToArray();
            var challenge5 = Input.Parse(inputLines5);
            Output.Write(challenge5.SolveSimpleWithFirstOpt(), $"output/sample5.out");

            Console.WriteLine("Team Endor go!!");
        }

        static void MainMartin(string[] args)
        {
            var inputLines1 = File.ReadAllLines($"input/sample1.in").ToArray();
            var challenge1 = Input.Parse(inputLines1);
            Output.Write(challenge1.CurrentBest(), $"output/sample1.out");

            var inputLines2 = File.ReadAllLines($"input/sample2.in").ToArray();
            var challenge2 = Input.Parse(inputLines2);
            Output.Write(challenge2.CurrentBestTake(250), $"output/sample2.out");

            var inputLines3 = File.ReadAllLines($"input/sample3.in").ToArray();
            var challenge3 = Input.Parse(inputLines3);
            Output.Write(challenge3.CurrentBestThree(), $"output/sample3.out");

            var inputLines4 = File.ReadAllLines($"input/sample4.in").ToArray();
            var challenge4 = Input.Parse(inputLines4);
            Output.Write(challenge4.CurrentBestTake(250), $"output/sample4.out");

            var inputLines5 = File.ReadAllLines($"input/sample5.in").ToArray();
            var challenge5 = Input.Parse(inputLines5);
            Output.Write(challenge5.CurrentBestTake(250), $"output/sample5.out");

            Console.WriteLine("Team Endor go!!");
        }
    }
}
