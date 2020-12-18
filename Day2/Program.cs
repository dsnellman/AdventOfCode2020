using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\DanielSnellman\source\repos\AdventOfCode2020\Day2\input.txt");
            int n = 0;
            int x = 0;
            foreach (string line in lines)
            {
                string[] partOfline = line.Split(' ');
                int lowest = int.Parse(partOfline[0].Split('-')[0]);
                int highest = int.Parse(partOfline[0].Split('-')[1]);
                string character = partOfline[1].Replace(":", string.Empty);

                string Password = partOfline[2];
                char[] passWordArray = partOfline[2].ToCharArray();

                int count = Password.Length - Password.Replace(character, "").Length;
                if(count >= lowest && count <= highest)
                {
                    n++;
                }
                Boolean low = false, high = false;
                if (Password.Length + 1 > lowest)
                {
                    if (passWordArray[lowest - 1] == character.ToCharArray()[0])
                    {
                        low = true;
                    }
                }
                if (Password.Length + 1 > highest)
                {
                    if (passWordArray[highest - 1] == character.ToCharArray()[0])
                    {
                        high = true;
                    }
                }

                if(low ^ high)
                {
                    x++;
                }
                 
            }

            Console.WriteLine(n);
            Console.WriteLine(x);
        }
    }
}
