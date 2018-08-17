using System;
using System.Collections.Generic;
using System.IO;

namespace TextDivider
{
    class Program
    {
        static void Main(string[] args)
        {
            var textDivider = new TextDivider();
            var lines = File.ReadLines(@"Data\Input.txt");
            var results = new List<string>();

            foreach (var line in lines)
            {
                var numberEnd = line.IndexOf(' ');
                var lineLetterCount = Convert.ToInt32(line.Substring(0, numberEnd));
                var text = line.Substring(numberEnd);
                results.Add(textDivider.DivideText(text, lineLetterCount));
            }

            File.WriteAllLines(@"Data\Results.txt", results);
        }
    }
}
