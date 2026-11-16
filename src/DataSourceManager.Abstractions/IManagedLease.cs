using System;

namespace Infoconex.DataSourceManager
{
    /// <summary>Owns a provider-appropriate resource within an explicitly disposable lifetime.</summary>
    /// <typeparam name="TResource">A provider-specific resource contract.</typeparam>
    public interface IManagedLease<out TResource> : IDisposable where TResource : class
    {
        /// <summary>Gets the typed resource while the lease is valid.</summary>
        TResource Resource { get; }
    }
}
