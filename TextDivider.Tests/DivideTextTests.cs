using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextDivider.Tests
{
    [TestClass]
    public class DivideTextTests
    {
        [TestMethod]
        public void Divides_Text_To_Lines_Correctly()
        {
            var textDivider = new TextDivider();
            var result = textDivider.DivideText("þodis þodis þodis", 13);

            Assert.AreEqual(2, Regex.Matches(result, "\n").Count);

            var result2 = textDivider.DivideText("ðiuolaikiðkas ir mano þodis", 7);

            Assert.AreEqual(4, Regex.Matches(result2, "\n").Count);
        }

        [TestMethod]
        public void Divided_Text_In_Line_Is_Correct()
        {
            var textDivider = new TextDivider();
            var result = textDivider.DivideText("þodis þodis þodis", 13);
            ReadStringLines(result, (line) => Assert.IsTrue(line.Count(c => !Char.IsWhiteSpace(c)) <= 13));

            var result2 = textDivider.DivideText("ðiuolaikiðkas ir mano þodis", 7);
            ReadStringLines(result2, (line) => Assert.IsTrue(line.Count(c => !Char.IsWhiteSpace(c)) <= 7));
        }

        private void ReadStringLines(string text, Action<string> func = null)
        {
            using (var reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    func(line);
                }
            }
        }
    }
}
