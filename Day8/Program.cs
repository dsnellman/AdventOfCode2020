using System;
using System.Collections.Generic;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day8\input.txt");

            Console.WriteLine(part1(lines));
            Console.WriteLine(part2(lines));
        }

        public static int part1(string[] lines)
        {
            int acc = 0;
            List<int> usedIndex = new List<int>();
            for (int index = 0; index < lines.Length; index++)
            {
                string[] lineSplit = lines[index].Split(" ");

                if(usedIndex.Contains(index))
                {
                    return acc;
                }
                else
                {
                    usedIndex.Add(index);
                }

                switch (lineSplit[0])
                {
                    case "acc":
                        if (lineSplit[1].Substring(0, 1).Equals("+"))
                        {
                            acc += int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1));
                        }
                        else
                        {
                            acc -= int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1));
                        }

                        break;

                    case "jmp":
                        if (lineSplit[1].Substring(0, 1).Equals("+"))
                        {
                            index += int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1))-1;
                        }
                        else
                        {
                            index -= int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1))+1;
                        }
                        break;
                }
            }
            return acc;
        }

        public static int part2(string[] lines)
        {

            int acc = 0;
            List<int> usedIndex = new List<int>();
            List<int> changedIndex = new List<int>();
            int lastChangedIndex = 0;
            Boolean hasChanged = false;
            for (int index = 0; index < lines.Length; )
            {
                 string[] lineSplit = lines[index].Split(" ");

                if (usedIndex.Contains(index))
                {
                    usedIndex = new List<int>();
                    index = 0;
                    lastChangedIndex = 0;
                    hasChanged = false;
                    acc = 0;
                }
                else
                {
                    usedIndex.Add(index);

                    if (!changedIndex.Contains(index) && !hasChanged)
                    {
                        if (lineSplit[0].Equals("jmp"))
                        {
                            lineSplit[0] = "nop";
                            changedIndex.Add(index);
                            lastChangedIndex = index;
                            hasChanged = true;
                        }
                        else if (lineSplit[0].Equals("nop"))
                        {
                            lineSplit[0] = "jmp";
                            changedIndex.Add(index);
                            lastChangedIndex = index;
                            hasChanged = true;
                        }
                    }
                    switch (lineSplit[0])
                    {
                        case "acc":
                            if (lineSplit[1].Substring(0, 1).Equals("+"))
                            {
                                acc += int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1));
                            }
                            else
                            {
                                acc -= int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1));
                            }
                            index++;

                            break;

                        case "jmp":
                            if (lineSplit[1].Substring(0, 1).Equals("+"))
                            {
                                index += int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1));
                            }
                            else
                            {
                                index -= int.Parse(lineSplit[1].Substring(1, lineSplit[1].Length - 1));
                            }
                            break;

                        case "nop":
                            index++;
                            break;
                    }
                }
            }
            return acc;
        }
    }
}
