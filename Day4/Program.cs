using System;
using System.Collections.Generic;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day4\input.txt");

            int count = 0;
            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
            Dictionary<string, string> currentPassport = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                if (line.Equals(String.Empty))
                {
                    passports.Add(currentPassport);
                    currentPassport = new Dictionary<string, string>();
                }
                else
                {
                    string[] splitLine = line.Split(' ');
                    foreach (string PortOfLine in splitLine)
                    {
                        currentPassport.Add(PortOfLine.Split(':')[0], PortOfLine.Split(':')[1]);
                    }
                }
            }
            passports.Add(currentPassport);

            string[] required = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            foreach (Dictionary<string, string> passport in passports)
            {
                bool valid = true;
                foreach(string key in required)
                {
                    if(!passport.ContainsKey(key))
                    {
                        valid = false;
                    }
                }
                if(valid)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }

}
