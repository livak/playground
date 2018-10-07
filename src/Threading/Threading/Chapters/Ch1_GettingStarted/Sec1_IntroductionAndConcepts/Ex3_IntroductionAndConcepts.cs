using System;
using System.Threading;

namespace Threading.Chapters.Ch1_GettingStarted.Sec1_IntroductionAndConcepts
{
    /// <summary>
    /// Shared variable
    /// </summary>
    public class Ex3_IntroductionAndConcepts
    {
        private static bool done = false;

        public void Start()
        {
            var t = new Thread(Go);
            t.Start();
            Go();
        }

        private static void Go()
        {
            if(!done)
            {
                Console.WriteLine("Done!");
                done = true;
            }
        }
    }
}