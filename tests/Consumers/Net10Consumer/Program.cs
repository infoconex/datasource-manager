using System;
using System.Reflection;
using System.Threading;
using Manager = Infoconex.DataSourceManager.Core.Application.DataSourceManager;

namespace Infoconex.DataSourceManager.Consumers
{
    internal static class Program
    {
        private static int Main()
        {
            foreach (var assemblyName in new[] { "DataSourceManager.Abstractions", "DataSourceManager.Core" })
            {
                var assembly = Assembly.Load(new AssemblyName(assemblyName));
                if (!string.Equals(assembly.GetName().Name, assemblyName, StringComparison.Ordinal))
                {
                    Console.Error.WriteLine("Unexpected package assembly: " + assemblyName);
                    return 1;
                }
                Console.WriteLine("Loaded " + assembly.GetName().FullName);
            }

            IDataSourceManager manager = new Manager();
            var result = manager.AcquireAsync<object>(
                new AcquisitionRequest("unregistered-provider", "test-profile"),
                CancellationToken.None).GetAwaiter().GetResult();
            if (result.Outcome != AcquisitionOutcome.UnsupportedProvider || result.Succeeded || result.Lease != null)
            {
                Console.Error.WriteLine("POC-SCN-01: expected typed UnsupportedProvider without a lease.");
                return 1;
            }

            Console.WriteLine("POC-SCN-01: net10 zero-provider acquisition returned UnsupportedProvider.");
            return 0;
        }
    }
}

