using System;
using System.Collections.Generic;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day5\input.txt");

            Console.WriteLine(part1(lines));
            Console.WriteLine(part2(lines));
        }


        public static int part1(String[] lines)
        {
            int row;
            int column;
            int highest = 0;
            List<int> ids = new List<int>();


            foreach(string line in lines)
            {
                row = find(line.Substring(0, 1), line.Substring(1,line.Length-4), 0, 127);
                column = find(line.Substring(line.Length-3, 1), line.Substring(line.Length-2, 2), 0, 7);

                if (highest <= (row * 8 + column))
                {
                    highest = (row * 8 + column);
                }
            }
            
            return highest;
        }

        public static int part2(String[] lines)
        {
            int row = 0;
            int column = 0;
            List<int> ids = new List<int>();

            foreach (string line in lines)
            {
                row = find(line.Substring(0, 1), line.Substring(1, line.Length - 4), 0, 127);
                column = find(line.Substring(line.Length - 3, 1), line.Substring(line.Length - 2, 2), 0, 7);
                ids.Add(row * 8 + column);
            }

            ids.Sort();

            for(int r = 0; r <= 127; r++)
            {
                for (int c = 0; c <= 7; c++)
                {
                    if(!ids.Contains(r*8+c) && ids.Contains((r * 8 + c)-1) && ids.Contains((r * 8 + c) + 1))
                    {
                        return (r * 8 + c);
                    }
                }
            }
            
            return 0;
        }

        public static int find(string NextChar, string Rest, int min, int max)
        {
            if (NextChar.Equals("F") || NextChar.Equals("L"))
            {
                max = (int)Math.Floor((double)(min + max) / 2);
            }
            else if (NextChar.Equals("B") || NextChar.Equals("R"))
            {
                min = (int)Math.Ceiling((double)(min + max) / 2);
            }

            if (Rest.Equals(""))
                return min;

            return find(Rest.Substring(0, 1), Rest.Substring(1, Rest.Length-1), min, max);
        }
        
    }
}
