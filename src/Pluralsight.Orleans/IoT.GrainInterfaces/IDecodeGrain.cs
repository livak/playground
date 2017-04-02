using Orleans;
using System.Threading.Tasks;

namespace IoT.GrainInterfaces
{
    public interface IDecodeGrain : IGrainWithIntegerKey
    {
        Task Decode(string message);
    }
}
