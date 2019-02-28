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
                var inputLines = File.ReadAllLines($"input/sample{i}.in").ToArray();
                var challenge = Input.Parse(inputLines);
                Output.Write(challenge.SolveIt(), $"output/sample{i}.out");
            }

            // var inputLines = File.ReadAllLines($"input/sample3.in").ToArray();
            // var challenge = Input.Parse(inputLines);
            // Output.Write(challenge.SolveStupid(), $"output/sample3.out");


            Console.WriteLine("Team Endor go!!");
        }
    }
}
