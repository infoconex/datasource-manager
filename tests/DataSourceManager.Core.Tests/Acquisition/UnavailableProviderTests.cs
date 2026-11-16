using System;
using System.Threading;
using System.Threading.Tasks;
using Manager = Infoconex.DataSourceManager.Core.Application.DataSourceManager;
using NUnit.Framework;

namespace Infoconex.DataSourceManager.Core.Tests.Acquisition
{
    [TestFixture]
    public sealed class UnavailableProviderTests
    {
        [Test]
        public void CoreCanBeConstructedWithNoAdapters()
        {
            IDataSourceManager manager = new Manager();

            Assert.That(manager, Is.Not.Null);
        }

        [Test]
        public async Task UnregisteredProviderReturnsTypedUnsupportedOutcome()
        {
            IDataSourceManager manager = new Manager();
            var request = new AcquisitionRequest("not-registered", "test-profile");

            AcquisitionResult<object> result = await manager.AcquireAsync<object>(request, CancellationToken.None);

            Assert.Multiple(() =>
            {
                Assert.That(result.Outcome, Is.EqualTo(AcquisitionOutcome.UnsupportedProvider));
                Assert.That(result.Succeeded, Is.False);
                Assert.That(result.Lease, Is.Null);
            });
        }

        [Test]
        public async Task ALoadableTypeDoesNotBecomeAnImplicitProvider()
        {
            IDataSourceManager manager = new Manager();
            var request = new AcquisitionRequest(typeof(UnregisteredProvider).FullName!, "test-profile");

            AcquisitionResult<object> result = await manager.AcquireAsync<object>(request, CancellationToken.None);

            Assert.That(result.Outcome, Is.EqualTo(AcquisitionOutcome.UnsupportedProvider));
            Assert.That(UnregisteredProvider.WasConstructed, Is.False);
        }

        [TestCase("", "test-profile", "providerId")]
        [TestCase(" ", "test-profile", "providerId")]
        [TestCase("not-registered", "", "profileId")]
        [TestCase("not-registered", " ", "profileId")]
        public void RequestRejectsMissingIdentifiers(string providerId, string profileId, string parameter)
        {
            var exception = Assert.Throws<ArgumentException>(() => new AcquisitionRequest(providerId, profileId));

            Assert.That(exception!.ParamName, Is.EqualTo(parameter));
        }

        private sealed class UnregisteredProvider
        {
            internal static bool WasConstructed { get; private set; }

            public UnregisteredProvider()
            {
                WasConstructed = true;
            }
        }
    }
}
