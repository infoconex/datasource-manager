using System.Threading;
using System.Threading.Tasks;

namespace Infoconex.DataSourceManager
{
    /// <summary>The inbound boundary for acquiring provider-appropriate resources.</summary>
    public interface IDataSourceManager
    {
        /// <summary>Attempts acquisition using only explicitly registered providers.</summary>
        /// <typeparam name="TResource">The requested provider-specific resource contract.</typeparam>
        /// <param name="request">An explicit provider and profile request.</param>
        /// <param name="cancellationToken">Cancellation of manager-owned work; not a remote-operation guarantee.</param>
        /// <returns>A managed lease or typed, redacted failure.</returns>
        Task<AcquisitionResult<TResource>> AcquireAsync<TResource>(
            AcquisitionRequest request,
            CancellationToken cancellationToken) where TResource : class;
    }
}
