using System;
using System.Threading;

namespace Threading.Chapters.Ch1_GettingStarted.Sec1_IntroductionAndConcepts
{
    /// <summary>   
    /// http://www.albahari.com/threading/#_Introduction
    /// Do something in parallel on new thread
    /// </summary>
    public class Ex1_IntroductionAndConcepts
    {
        public void Start()
        {
            var t = new Thread(WriteY); // create a new thread
            t.Start();                  // running WriteY()

            // do something on the main thread
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
            }

            while (t.IsAlive)
            {
                System.Console.WriteLine("alive");
            }
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }
}