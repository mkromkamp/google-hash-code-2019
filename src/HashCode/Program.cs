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
            var inputLines = File.ReadAllLines("input/sample.in").ToList();
            var challenge = Input.Parse(inputLines);
            
            var solutions = new Dictionary<string, Solution>
            {
                { "output/sample.out", challenge.SolveSimple() },
            };
            
            foreach (var solution in solutions)
            {
                Output.Write(solution.Value, solution.Key);
            }

            Console.WriteLine("Team Endor go!!");
        }
    }
}
