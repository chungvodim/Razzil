using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Razzil.Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Not enough parameters, please enter inputPath and bank");
                }
                else
                {
                    string pattern = @"<option value=""(\d+)"">(.+)</option>";
                    var regex = new Regex(pattern);
                    var inputPath = args[0];
                    var bank = args[1];
                    var outputPath = inputPath.Insert(inputPath.LastIndexOf("."), "_Parsed");
                    Console.WriteLine("input path: " + inputPath);
                    Console.WriteLine("output path: " + outputPath);
                    Console.WriteLine("bank: " + bank);

                    //var lines = File.ReadAllLines(@"C:\Temp\PMT_InterBank.txt");
                    var lines = File.ReadAllLines(inputPath);
                    var i = 1;
                    if(File.Exists(outputPath))
                    {
                        File.Delete(outputPath);
                    }
                    foreach (var line in lines)
                    {
                        var match = regex.Match(line);
                        var value = match.Groups[1].Value;
                        var text = match.Groups[2].Value;
                        var newLine = "INSERT INTO wx_tobanks set oid = " + value + ", from_bank = '" + bank + "', to_bank = '" + text + "', display_order = " + i + ";" + "\n";
                        File.AppendAllText(outputPath, newLine);
                        i++;
                    }
                    Console.WriteLine("Generate successful");
                }
                Console.WriteLine("Enter anykey to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
