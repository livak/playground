using System;
using System.Threading;

namespace Threading.Chapters.Ch1_GettingStarted.Sec1_IntroductionAndConcepts
{
    /// <summary>
    /// Local variables are separate on each thread
    /// </summary>
    public class Ex2_IntroductionAndConcepts
    {
        public void Start()
        {
            var t = new Thread(Go);
            t.Start();
            Go();
        }

        private static void Go()
        {
            // use a local variable i
            for (var i = 0; i < 5; i++)
            {
                Console.Write(i);
            }
        }
    }
}