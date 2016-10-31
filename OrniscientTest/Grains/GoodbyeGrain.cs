using System.Threading.Tasks;
using OrniscientTest.GrainInterfaces;

namespace OrniscientTest.Grains
{
    public class GoodbyeGrain : HelloWorldGrain, IGoodbyeGrain
    {
        public override Task OnActivateAsync()
        {
            this.m_Text = "Goodbye";

            return base.OnActivateAsync();
        }
    }
}
