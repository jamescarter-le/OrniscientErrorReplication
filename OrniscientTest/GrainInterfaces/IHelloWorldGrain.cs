using System.Threading.Tasks;
using Orleans;

namespace OrniscientTest.GrainInterfaces
{
    public interface IHelloWorldGrain : IGrainWithStringKey
    {
        Task<string> SayHello(string name);
    }
}
