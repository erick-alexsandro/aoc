using System;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;

namespace aoc
{
    class Part2
    {
        static void Main(string[] args)
        {
            string line;

            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

                StreamReader sr = new StreamReader($"{projectDirectory}\\input");

                long sum = 0;
                int numberOfLines = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    var allNumbers = new Dictionary<string, int>()
                {
                    {"zero", 0},
                    {"one", 1},
                    {"two", 2},
                    {"three", 3},
                    {"four", 4},
                    {"five", 5},
                    {"six", 6},
                    {"seven", 7},
                    {"eight", 8},
                    {"nine", 9}
                };

                    for (int i = 0; i < 10; i++)
                    {
                        allNumbers.Add(i.ToString(), i);
                    }

                    int firstIndex = line.Length;
                    int lastIndex = -1;
                    int firstNumber = 0;
                    int lastNumber = 0;

                    foreach (var num in allNumbers)
                    {
                        var index = line.IndexOf(num.Key);
                        if (index != -1 && index < firstIndex)
                        {
                            firstIndex = index;
                            firstNumber = num.Value;
                        }
                        index = line.LastIndexOf(num.Key);
                        if (index != -1 && index > lastIndex)
                        {
                            lastIndex = index;
                            lastNumber = num.Value;
                        }
                    }

                    int fullNumber = firstNumber * 10 + lastNumber;

                    sum += fullNumber;
                    numberOfLines++;
                    Console.WriteLine($"Line {numberOfLines}: {firstNumber}{lastNumber}");
                }

                Console.WriteLine($"The sum of all calibration values is {sum}");

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
