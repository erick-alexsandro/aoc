using System.Globalization;
using System.Text.RegularExpressions;
namespace aoc;

class Part2
{
    static void Main(string[] args)
    {
        String line;
        try
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            
            int numberOfLines = 0;
            int sum = 0;
            StreamReader sr = new StreamReader($"{projectDirectory}\\input");

            line = sr.ReadLine();

            while(line != null)
            {
                char firstNumber = ' ';
                char lastNumber = ' ';
                string number;
                numberOfLines = numberOfLines + 1;
                foreach (char c in line){
                    if (Char.IsDigit(c)){
                        firstNumber = c;
                        break;
                    }
                    
                }
                for (int i = line.Length - 1; i >= 0; i--){
                    if (Char.IsDigit(line[i])){
                        lastNumber = line[i];
                        break;
                    }
                }
                number = firstNumber.ToString() + lastNumber.ToString();

                sum += int.Parse(number);
                line = sr.ReadLine();
                System.Console.WriteLine($"Line {numberOfLines}: {firstNumber}{lastNumber}");   
            }

            System.Console.WriteLine($"The sum of all calibration values is {sum}");

            sr.Close();

            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}
