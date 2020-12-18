    using System;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day1\input.txt");

            foreach(string line in lines)
            {
                int currentLine = int.Parse(line);
                for (int x = 0; x < lines.Length; x++)
                {
                    int secondInt = int.Parse(lines[x]);
                    for(int n = 0; n < lines.Length; n++)
                    {
                        int thirdInt = int.Parse(lines[n]);
                        if((currentLine + secondInt + thirdInt) == 2020)
                        {
                            Console.WriteLine(currentLine + " * " + secondInt + " * " + thirdInt + " = " + (currentLine * secondInt * thirdInt));
                        }
                    }
                }
            }
        }
    }
}
