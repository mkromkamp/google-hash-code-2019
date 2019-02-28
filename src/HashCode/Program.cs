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
                if (i != 3)
                {
                    var inputLines = File.ReadAllLines($"input/sample{i}.in").ToArray();
                    var challenge = Input.Parse(inputLines);
                    Output.Write(challenge.CurrentBest(), $"output/sample{i}.out");
                }
            }

            var inputLines3 = File.ReadAllLines($"input/sample3.in").ToArray();
            var challenge3 = Input.Parse(inputLines3);
            Output.Write(challenge3.CurrentBestThree(), $"output/sample3.out");


            Console.WriteLine("Team Endor go!!");
        }
    }
}
