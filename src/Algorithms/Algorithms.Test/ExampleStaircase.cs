using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Test
{

    [TestClass]
    public class ExampleStaircase
    {
        [TestMethod]
        public void Test(int n)
        {
            string strSpace = new string(' ', n);
            string strHash = new string('#', n);
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(string.Concat(
                    strSpace.Substring(0, n - i - 1),
                    strHash.Substring(0, i + 1)));
            }
        }
    }
}
