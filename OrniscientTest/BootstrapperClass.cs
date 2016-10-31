using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using OrniscientTest.GrainInterfaces;

namespace OrniscientTest
{
    public class BootstrapperClass : IBootstrapProvider
    {
        public async Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config)
        {
            Name = name;

            await providerRuntime.GrainFactory.GetGrain<IHelloWorldGrain>("Hello").SayHello("James");
            await providerRuntime.GrainFactory.GetGrain<IHelloWorldGrain>("Bonjour").SayHello("James");
            await providerRuntime.GrainFactory.GetGrain<IHelloWorldGrain>("Halo").SayHello("James");

            await providerRuntime.GrainFactory.GetGrain<IGoodbyeGrain>("TEST").SayHello("James");
        }

        public Task Close()
        {
            return TaskDone.Done;
        }

        public string Name { get; private set; }
    }
}
