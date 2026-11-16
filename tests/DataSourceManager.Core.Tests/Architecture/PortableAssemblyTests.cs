using System;
using System.Linq;
using NUnit.Framework;

namespace Infoconex.DataSourceManager.Core.Tests.Architecture
{
    [TestFixture]
    public sealed class PortableAssemblyTests
    {
        [Test]
        public void FoundationAssembliesRemainDistinct()
        {
            var core = System.Reflection.Assembly.Load("DataSourceManager.Core");
            var abstractions = System.Reflection.Assembly.Load("DataSourceManager.Abstractions");

            Assert.That(core.GetName().Name, Is.EqualTo("DataSourceManager.Core"));
            Assert.That(abstractions.GetName().Name, Is.EqualTo("DataSourceManager.Abstractions"));
            Assert.That(core.GetType("Infoconex.DataSourceManager.Core.Domain.FoundationAssemblyMarker"), Is.Not.Null);
            Assert.That(abstractions.GetType("Infoconex.DataSourceManager.FoundationAssemblyMarker"), Is.Not.Null);
        }

        [Test]
        public void PortableAssembliesDoNotReferenceProviderOrResiliencePackages()
        {
            var core = System.Reflection.Assembly.Load("DataSourceManager.Core");
            var abstractions = System.Reflection.Assembly.Load("DataSourceManager.Abstractions");
            var forbidden = new[] { "Microsoft.Data.SqlClient", "Npgsql", "MySqlConnector", "Polly", "SSH.NET", "Microsoft.Extensions.DependencyInjection" };

            foreach (var assembly in new[] { core, abstractions })
            {
                var references = assembly.GetReferencedAssemblies().Select(reference => reference.Name).ToArray();
                Assert.That(references.Intersect(forbidden, StringComparer.OrdinalIgnoreCase), Is.Empty,
                    assembly.GetName().Name + " must remain provider-neutral");
            }
        }
    }
}
