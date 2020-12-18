using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day4\input.txt");

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


            Console.WriteLine(part1(passports));
            Console.WriteLine(part2(passports));
        }


        public static int part1(List<Dictionary<string, string>> passports)
        {
            int count = 0;
            string[] required = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            foreach (Dictionary<string, string> passport in passports)
            {
                bool valid = true;
                foreach (string key in required)
                {
                    if (!passport.ContainsKey(key))
                    {
                        valid = false;
                    }
                }
                if (valid)
                {
                    count++;
                }
            }

            return count;
        }


        public static int part2(List<Dictionary<string, string>> passports)
        {
            int count = 0;
            string[] required = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            foreach (Dictionary<string, string> passport in passports)
            {
                bool valid = true;
                foreach (string key in required)
                {
                    if (!passport.ContainsKey(key))
                    {
                        valid = false;
                    }
                    if (valid)
                    {
                        switch (key)
                        {
                            case "byr":
                                valid = isLengthEquel(passport[key], 4) && isBetween(passport[key],1920, 2002);
                                break;

                            case "iyr":
                                valid = isLengthEquel(passport[key], 4) && isBetween(passport[key], 2010, 2020);
                                break;

                            case "eyr":
                                valid = isLengthEquel(passport[key], 4) && isBetween(passport[key], 2020, 2030);
                                break;

                            case "hgt":
                                valid = passport[key].Substring(passport[key].Length - 2, 2).Equals("cm") ? isBetween(passport[key].Substring(0, passport[key].Length-2) , 150, 193) : passport[key].Substring(passport[key].Length - 2, 2).Equals("in") ? isBetween(passport[key].Substring(0, passport[key].Length - 2), 59, 76) : false;
                                break;

                            case "hcl":
                                valid = new Regex("^#[0-9a-f]{6}$").IsMatch(passport[key]);
                                break;

                            case "ecl":
                                string[] colors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                valid = Array.IndexOf(colors, passport[key]) > -1;
                                break;

                            case "pid":
                                valid = new Regex("^[0-9]{9}$").IsMatch(passport[key]);
                                break;
                        }
                    }

                }
                if (valid)
                { 
                    count++;
                }
            }

            return count;
        }

        public static Boolean isLengthEquel(string s, int l)
        {
            return s.Length == l;
        }

        public static Boolean isBetween(string s, int f, int l)
        {
            return int.Parse(s) >= f && int.Parse(s) <= l;
        }

        
    }
}
