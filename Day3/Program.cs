using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day3\input.txt");
            string total = (countTrees(lines, 1, 1) * countTrees(lines, 3, 1) * countTrees(lines, 5, 1) * countTrees(lines, 7, 1) * countTrees(lines, 1, 2)).ToString();

            Console.WriteLine("Trees hit: " + total);
        }
        
        public static Int64 countTrees(string[] lines, int right, int down)
        {
            int hitTrees = 0;
            int lineN = 0;
            int lineDone = 0;
            foreach (string line in lines)
            {
                if (lineN % down == 0)
                {
                    int n = (lineDone * right) % (line.Length);
                    char[] lineArray = line.ToCharArray();
                    if (lineArray[n].Equals('#'))
                    {
                        hitTrees++;
                    }
                    lineDone++;
                }
                lineN++;
            }

            return hitTrees;
        }
    }
}
