using System.Threading.Tasks;
using Derivco.Orniscient.Proxy.Attributes;
using Orleans;
using OrniscientTest.GrainInterfaces;

namespace OrniscientTest.Grains
{
    public class HelloWorldGrain : Grain, IHelloWorldGrain
    {
        protected string m_Text;

        public override Task OnActivateAsync()
        {
            m_Text = this.GetPrimaryKeyString();

            return base.OnActivateAsync();
        }

        [OrniscientMethod]
        public Task<string> SayHello(string name)
        {
            return Task.FromResult(m_Text + ", " + name);
        }
    }
}
