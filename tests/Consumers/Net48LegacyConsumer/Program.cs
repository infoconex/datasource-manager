using System;
using System.Reflection;

namespace Infoconex.DataSourceManager.Consumers
{
    internal static class Program
    {
        private static int Main()
        {
            foreach (string assemblyName in new[] { "DataSourceManager.Abstractions", "DataSourceManager.Core" })
            {
                Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
                if (!string.Equals(assembly.GetName().Name, assemblyName, StringComparison.Ordinal))
                {
                    Console.Error.WriteLine("Unexpected package assembly: " + assemblyName);
                    return 1;
                }

                Console.WriteLine("Loaded " + assembly.GetName().FullName);
            }

            Console.WriteLine("net48 foundation package-load smoke passed; no POC capability was exercised.");
            return 0;
        }
    }
}
