using System;
using System.Threading.Tasks;

using Orleans;
using Orleans.Runtime.Configuration;
using IoT.GrainInterfaces;

namespace IoT.TestSilo
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // The Orleans silo environment is initialized in its own app domain in order to more
            // closely emulate the distributed situation, when the client and the server cannot
            // pass data via shared memory.
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            {
                AppDomainInitializer = InitSilo,
                AppDomainInitializerArguments = args,
            });

            var config = ClientConfiguration.LocalhostSilo();
            GrainClient.Initialize(config);

            // TODO: once the previous call returns, the silo is up and running.
            //       This is the place your custom logic, for example calling client logic
            //       or initializing an HTTP front end for accepting incoming requests.

            Console.WriteLine("Orleans Silo is running.\nEnter exit to terminate...");

            Console.ReadLine();
            var grain = GrainClient.GrainFactory.GetGrain<IDeviceGrain>(1);

            string line = null;

            while (line != "exit")
            {
                line = Console.ReadLine();
                double temperature;
                if (double.TryParse(line, out temperature))
                {
                    grain.SetTemperature(temperature);
                }
                else if (line == "exit")
                {
                    hostDomain.DoCallBack(ShutdownSilo);
                }
                else
                {
                    Console.WriteLine("Not supported command");
                }
            }
        }

        static void InitSilo(string[] args)
        {
            hostWrapper = new OrleansHostWrapper(args);

            if (!hostWrapper.Run())
            {
                Console.Error.WriteLine("Failed to initialize Orleans silo");
            }
        }

        static void ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                hostWrapper.Dispose();
                GC.SuppressFinalize(hostWrapper);
            }
        }

        private static OrleansHostWrapper hostWrapper;
    }
}
