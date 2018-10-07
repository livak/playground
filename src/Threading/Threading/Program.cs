using System;
using System.Collections.Generic;
using Threading.Chapters;
using Threading.Chapters.Ch1_GettingStarted.Sec1_IntroductionAndConcepts;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            new Ex4_IntroductionAndConcepts().Start();
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
