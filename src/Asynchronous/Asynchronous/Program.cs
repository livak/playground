using Asynchronous.Examples;
using System;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * We could use library:
             * https://github.com/StephenCleary/AsyncEx.Context
             * https://blog.stephencleary.com/2012/02/async-console-programs.html
             * Nito.AsyncEx.AsyncContext.Run(() => MainAsync(args));
             * Or: 
             * SingleThreadSynchronizationContext 
             *  https://blogs.msdn.microsoft.com/pfxteam/2012/01/20/await-synchronizationcontext-and-console-apps/
             *  
             *  But for simplicity I am using something similar that maybe become integrated in c#:
             *  https://github.com/dotnet/roslyn/issues/7476
             *  https://github.com/dotnet/csharplang/blob/master/proposals/async-main.md
            */

            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            var t =  Example1.Start();
            Console.WriteLine("Main has control and It is awaiting");
            await t;
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}