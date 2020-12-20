using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day7\input.txt");

            Dictionary<string, Dictionary<string, int>> bagRules = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> currentRule;
            foreach (string line in lines)
            {
                currentRule = new Dictionary<string, int>();
                string[] lineSplit = line.Split(" contain ");
                string[] containSplit = lineSplit[1].Split(", ");
                foreach (string c in containSplit)
                {
                    if (!containSplit[0].Substring(0, 2).Equals("no"))
                    {
                        currentRule.Add(
                            Regex.Replace(c, "[^a-zA-Z\\s]", "").Replace("bags", "bag").Trim(),
                            int.Parse(Regex.Replace(c, "[^0-9]", ""))
                        );
                    }
                }
                bagRules.Add(lineSplit[0].Replace("bags", "bag"), currentRule);
            }

            Console.WriteLine("part1: " + bagContains(bagRules, "shiny gold bag", new List<string>()).Count);
            Console.WriteLine("part2: " + toatalbags(bagRules, "shiny gold bag"));
        }



        public static List<string> bagContains(Dictionary<string, Dictionary<string, int>> bagRules, string searchBag, List<string> possibleColors)
        {
            foreach (var bag in bagRules)
            {
                if (bag.Value.ContainsKey(searchBag))
                {
                    if (!possibleColors.Contains(bag.Key))
                    {
                        possibleColors.Add(bag.Key);
                    }
                    possibleColors = bagContains(bagRules, bag.Key, possibleColors);
                }
            }
            return possibleColors;
        }


        public static int toatalbags(Dictionary<string, Dictionary<string, int>> bagRules, string searchBag)
        {
            int count = 0;
            foreach (var bag in bagRules.Where(x => x.Key == searchBag))
            {
                foreach(var containbag in bag.Value)
                {
                    count += containbag.Value;
                    count += containbag.Value * toatalbags(bagRules, containbag.Key);
                }
            }
            return count;
        }
    }
}
