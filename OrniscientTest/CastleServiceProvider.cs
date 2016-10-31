using System;
using Castle.MicroKernel;

namespace OrniscientTest
{
    public class CastleServiceProvider : IServiceProvider
    {
        private readonly IKernel m_Kernel;

        public CastleServiceProvider(IKernel kernel)
        {
            if (kernel == null) throw new ArgumentNullException(nameof(kernel));

            m_Kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return m_Kernel.Resolve(serviceType);
        }
    }
}
