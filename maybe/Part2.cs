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
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                string inputFilePath = Path.Combine(projectDirectory, "input");
                int lineNumber = 0;
                string[] numberWords = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                string[] reversedWords = numberWords.Select(ReverseString).ToArray();
                Regex regex = new Regex($"({string.Join("|", numberWords)})");
                Regex invertedRegex = new Regex($"({string.Join("|", reversedWords)})");
                int totalSum = 0;

                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string numberFirst = "";
                        string numberLast = "";
                        lineNumber++;

                        Match matchFirst = regex.Match(line);
                        if (matchFirst.Success)
                        {
                            numberFirst = matchFirst.Value;
                        }

                        string invertedLine = new string(line.Reverse().ToArray());

                        Match matchLast = invertedRegex.Match(invertedLine);
                        if (matchLast.Success)
                        {
                            numberLast = ReverseString(matchLast.Value);
                        }

                        string number = $"{ConvertNumberWordToNumber(numberFirst)}{ConvertNumberWordToNumber(numberLast)}";
                        Console.WriteLine($"Line {lineNumber}: {number}");
                        totalSum += Int32.Parse(number);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        
        static int ConvertNumberWordToNumber(string numberWord)
        {
            switch (numberWord)
            {
                case "zero":
                    return 0;
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                default:
                    return 0; 
            }
        }

        static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
