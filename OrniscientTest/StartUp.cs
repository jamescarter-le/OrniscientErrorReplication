using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.DependencyInjection;
using Orleans;

namespace OrniscientTest
{
    public class Startup
    {
        private IServiceProvider m_ServiceProvider;

        public IServiceProvider ConfigureServices(IServiceCollection orleansServiceCollection)
        {
            var container = new WindsorContainer();

            SetupOrleansDI(container, orleansServiceCollection);

            m_ServiceProvider = new CastleServiceProvider(container.Kernel);
            return m_ServiceProvider;
        }
        
        private void SetupOrleansDI(IWindsorContainer container, IServiceCollection orleansServiceCollection)
        {
            // Register all our Grains inside the Assembly (there should be none?)
            container.Register(Classes.FromThisAssembly().BasedOn<Grain>().LifestyleTransient());

            container.Register(Classes.FromAssemblyNamed("Derivco.Orniscient.Proxy").BasedOn<Grain>().LifestyleTransient());

            // Register those services which have been provided to us by the Orleans Framework
            foreach (var orleansService in orleansServiceCollection)
            {
                var component = Component.For(orleansService.ServiceType).UsingFactoryMethod(x => orleansService.ImplementationFactory(m_ServiceProvider));
                switch (orleansService.Lifetime)
                {
                    case ServiceLifetime.Singleton:
                        component = component.LifestyleSingleton();
                        break;
                    case ServiceLifetime.Transient:
                        component = component.LifestyleTransient();
                        break;
                    case ServiceLifetime.Scoped:
                        var error = $"Scoped lifestyle not supported for '{orleansService.ServiceType.Name}'.";
                        throw new InvalidOperationException(error);
                }
                container.Register(component);
            }
        }
    }
}
