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
            for (int i = 1; i < 6; i++)
            {
                if (i != 3 && i != 2 && i != 4)
                {
                    var inputLines = File.ReadAllLines($"input/sample{i}.in").ToArray();
                    var challenge = Input.Parse(inputLines);
                    Output.Write(challenge.CurrentBest(), $"output/sample{i}.out");
                }
            }

            var inputLines2 = File.ReadAllLines($"input/sample2.in").ToArray();
            var challenge2 = Input.Parse(inputLines2);
            Output.Write(challenge2.CurrentBestTake(100), $"output/sample2.out");

            var inputLines3 = File.ReadAllLines($"input/sample3.in").ToArray();
            var challenge3 = Input.Parse(inputLines3);
            Output.Write(challenge3.CurrentBestThree(), $"output/sample3.out");

            var inputLines4 = File.ReadAllLines($"input/sample4.in").ToArray();
            var challenge4 = Input.Parse(inputLines4);
            Output.Write(challenge4.CurrentBestTake(100), $"output/sample4.out");

            Console.WriteLine("Team Endor go!!");
        }
    }
}
