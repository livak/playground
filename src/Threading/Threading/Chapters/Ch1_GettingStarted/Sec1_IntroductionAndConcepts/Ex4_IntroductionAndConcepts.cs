using System;
using System.Threading;

namespace Threading.Chapters.Ch1_GettingStarted.Sec1_IntroductionAndConcepts
{
    /// <summary>
    /// Shared variable and lock
    /// </summary>
    public class Ex4_IntroductionAndConcepts
    {
        private static bool done = false;
        private static object locker = new object();

        public void Start()
        {
            var t = new Thread(Go);
            t.Start();
            Go();
        }

        private static void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Done!");
                    done = true;
                }
            }
        }
    }
}