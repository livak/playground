using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Test
{
    [TestClass]
    public class AlgorithmExample
    {
        [TestMethod]
        public void Test1()
        {
            var input = "i love solving problems and it is fun";
            Assert.AreEqual("I Love Solving Problems and It Is Fun", FormatTitle(input));
        }

        [TestMethod]
        public void Test2()
        {
            var input = "wHy DoeS A biRd Fly?";
            Assert.AreEqual("Why Does a Bird Fly?", FormatTitle(input));
        }

        [TestMethod]
        public void Test3()
        {
            var input = "";
            Assert.AreEqual("", FormatTitle(input));
        }

        static readonly List<string> lowerList = new List<string>() { "a", "the", "to", "at", "in", "with", "and", "but", "or" };
        public static string FormatTitle(string title)
        {
            title = title.ToLower();
            var words = title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                var isFirstOrLast = (i == 0 || i == words.Length - 1);
                if (isFirstOrLast || !lowerList.Contains(words[i]))
                {
                    words[i] = Capitalize(words[i]);
                }
            }

            return string.Join(" ", words);
        }

        public static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToUpper();
            }

            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }
    }
}
