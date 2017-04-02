using System;
using Orleans;
using Orleans.Runtime.Configuration;
using IoT.GrainInterfaces;
using IoT.TestSilo.Observers;
using IoT.GrainInterfaces.Observers;
using System.Linq;

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

            GrainClient.Initialize(); // default OrleansClientConfiguration.xml

            // TODO: once the previous call returns, the silo is up and running.
            //       This is the place your custom logic, for example calling client logic
            //       or initializing an HTTP front end for accepting incoming requests.

            Console.WriteLine("Orleans Silo is running.\nEnter exit to terminate...");

            Console.ReadLine();
            const string systemGrainName1 = "vehicle1";
            const string systemGrainName2 = "vehicle2";

            foreach (var deviceGrainId in Enumerable.Range(1,11))
            {
                GrainClient.GrainFactory.GetGrain<IDeviceGrain>(deviceGrainId)
                    .JoinSystem(deviceGrainId > 5 ? systemGrainName2 : systemGrainName1)
                    .Wait();
            }

            var observer = GrainClient.GrainFactory.CreateObjectReference<ISystemObserver>(new SystemObserver()).Result;

            GrainClient.GrainFactory.GetGrain<ISystemGrain>(systemGrainName1).Subscribe(observer);
            GrainClient.GrainFactory.GetGrain<ISystemGrain>(systemGrainName2).Subscribe(observer);

            var grain = GrainClient.GrainFactory.GetGrain<IDecodeGrain>(1);
            string line = null;
            while (line != "exit")
            {
                line = Console.ReadLine();
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int res) && double.TryParse(parts[1], out double temperature))
                {
                    grain.Decode(line);
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
