using Asynchronous.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Asynchronous.Examples
{
    public class Example1
    {
        public static async Task Start()
        {
            Console.WriteLine("Open notepad");
            var p = Process.Start("notepad.exe");
            Task<int> waitExitCode = p.WaitForCloseAsyinc();
            Console.WriteLine("Created task: waitExitCode for notepad");
            Console.WriteLine("await: control returned to caller");
            Console.WriteLine("Notepad close status code {0}", await waitExitCode);
        }
    }
}
