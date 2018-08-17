using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextDivider
{
    public class TextDivider
    {
        public string DivideText(string text, int letterCount)
        {
            var words = text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex($".{{{letterCount}}}");
            var builder = new StringBuilder();
            var line = string.Empty;

            foreach (var word in words)
            {
                var processedWords = new List<string>();

                if (word.Length > letterCount)
                {
                    var splittedWord = regex.Replace(word, "$&" + Environment.NewLine).Split(Environment.NewLine);
                    processedWords.AddRange(splittedWord);
                }
                else
                {
                    processedWords.Add(word);
                }

                foreach (var processedWord in processedWords)
                {
                    if (line.Count(c => !Char.IsWhiteSpace(c)) + processedWord.Length <= letterCount)
                    {
                        line += $"{processedWord} ";
                    }
                    else
                    {
                        builder.AppendLine(line);
                        line = $"{processedWord} ";
                    }
                }
            }

            builder.AppendLine(line);

            return builder.ToString();
        }
    }
}
