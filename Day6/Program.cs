using System;
using System.Collections.Generic;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day6\input.txt");

            Console.WriteLine(part1(lines));
            Console.WriteLine(part2(lines));
        }

        public static int part1(string[] lines)
        {
            int count = 0;
            List<List<char>> Groups = new List<List<char>>();
            List<char> currentGroup = new List<char>();

            foreach (string line in lines)
            {
                if (line.Equals(String.Empty))
                {
                    Groups.Add(currentGroup);
                    currentGroup = new List<char>();
                }
                else
                {
                    foreach (char question in line.ToCharArray())
                    {
                        if (!currentGroup.Contains(question))
                        {
                            currentGroup.Add(question);
                        }
                    }
                }
            }
            Groups.Add(currentGroup);

            foreach (List<char> group in Groups)
            {
                count += group.Count;
            }

            return count;
        }

        public static int part2(string[] lines)
        {
            List<List<char>> Groups = new List<List<char>>();
            List<char> currentGroup = new List<char>();
            Boolean newGroup = true;
            foreach (string line in lines)
            {
                if (line.Equals(String.Empty))
                {
                    Groups.Add(currentGroup);
                    newGroup = true;
                }
                else
                {
                    if (newGroup)
                    {
                        currentGroup = new List<char>();
                        currentGroup.AddRange(line.ToCharArray());
                        newGroup = false;
                    }
                    else
                    {
                        foreach (char question in currentGroup.ToArray())
                        {
                            if (!line.Contains(question))
                            {
                                currentGroup.Remove(question);
                            }
                        }
                    }
                }

            }
            Groups.Add(currentGroup);

            int count = 0;
            foreach (List<char> group in Groups)
            {
                count += group.Count;
            }

            return count;
        }
    }
}
