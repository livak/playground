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

            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(0).JoinSystem("vhiacle1").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(1).JoinSystem("vhiacle1").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(2).JoinSystem("vhiacle1").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(3).JoinSystem("vhiacle1").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(4).JoinSystem("vhiacle1").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(5).JoinSystem("vhiacle1").Wait();

            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(6 ).JoinSystem("vhiacle2").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(7 ).JoinSystem("vhiacle2").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(8 ).JoinSystem("vhiacle2").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(9 ).JoinSystem("vhiacle2").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(10).JoinSystem("vhiacle2").Wait();
            GrainClient.GrainFactory.GetGrain<IDeviceGrain>(11).JoinSystem("vhiacle2").Wait();

            var grain = GrainClient.GrainFactory.GetGrain<IDecodeGrain>(1);

            string line = null;

            while (line != "exit")
            {
                line = Console.ReadLine();
                var parts = line.Split(',');
                int res;
                double temperature;
                if (parts.Length == 2 && int.TryParse(parts[0], out res) && double.TryParse(parts[1], out temperature))
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
