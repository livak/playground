using System;
using System.Threading.Tasks;

namespace Asynchronous.Infrastructure
{
    public class TestAsyinc
    {
        public async Task<string> GetStringAsync(bool syinc)
        {
            Task<string> t1;
            Task<string> t2;

            if (syinc)
            {
                return "Pero";
            }
            else
            {
                t1 = Task.Run(async () =>
                {
                    Console.WriteLine("Task started");
                    await LongRunnoingTaskAsync();
                    Console.WriteLine("Task done");

                    return "Pero";
                });

                t2 = Task.Run(async () =>
                {
                    Console.WriteLine("Task2 started");
                    await LongRunnoingTaskAsync();
                    Console.WriteLine("Task2 done");

                    return "Pero2";
                });
                Console.WriteLine("Return control to caller");
                return await t1 + await t2;
            }
        }

        public async Task LongRunnoingTaskAsync()
        {
            await Task.Delay(1000);
        }
    }
}