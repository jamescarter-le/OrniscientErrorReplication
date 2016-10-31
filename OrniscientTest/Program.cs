using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Orleans.Runtime.Host;

namespace OrniscientTest
{
    class Program
    {
        private static SiloHost m_SiloHost;

        static void Main(string[] args)
        {
            m_SiloHost = new SiloHost(Dns.GetHostName())
            {
                ConfigFileName = "OrleansConfiguration.xml"
            };

            m_SiloHost.InitializeOrleansSilo();
            var startedok = m_SiloHost.StartOrleansSilo();
            if (!startedok)
            {
                throw new SystemException(
                    $"Failed to start Orleans silo '{m_SiloHost.Name}' as a {m_SiloHost.Type} node");
            }

            Console.ReadLine();
        }
    }
}
