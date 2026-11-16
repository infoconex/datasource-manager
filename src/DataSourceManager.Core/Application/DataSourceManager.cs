using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infoconex.DataSourceManager.Core.Application
{
    /// <summary>The initial provider-neutral manager, deliberately configured with no adapters.</summary>
    public sealed class DataSourceManager : IDataSourceManager
    {
        /// <inheritdoc />
        public Task<AcquisitionResult<TResource>> AcquireAsync<TResource>(
            AcquisitionRequest request,
            CancellationToken cancellationToken) where TResource : class
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // I1 exposes no registration or ambient discovery path. An explicit adapter
            // boundary and its trust policy are separate, gated I2 work.
            return Task.FromResult(AcquisitionResult<TResource>.UnsupportedProvider());
        }
    }
}
