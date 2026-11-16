using System;

namespace Infoconex.DataSourceManager
{
    /// <summary>Represents a typed resource lease or an explicit acquisition failure.</summary>
    /// <typeparam name="TResource">The requested provider-specific resource contract.</typeparam>
    public sealed class AcquisitionResult<TResource> where TResource : class
    {
        private AcquisitionResult(AcquisitionOutcome outcome, IManagedLease<TResource>? lease)
        {
            Outcome = outcome;
            Lease = lease;
        }

        /// <summary>Gets the structured outcome.</summary>
        public AcquisitionOutcome Outcome { get; }

        /// <summary>Gets a managed lease on success; otherwise null.</summary>
        public IManagedLease<TResource>? Lease { get; }

        /// <summary>Gets whether a lease was successfully acquired.</summary>
        public bool Succeeded => Outcome == AcquisitionOutcome.Acquired;

        /// <summary>Creates a redacted failure when no trusted provider has been registered.</summary>
        public static AcquisitionResult<TResource> UnsupportedProvider()
        {
            return new AcquisitionResult<TResource>(AcquisitionOutcome.UnsupportedProvider, null);
        }

        /// <summary>Creates a success result around an owned lease. No provider implementation is supplied here.</summary>
        public static AcquisitionResult<TResource> Acquired(IManagedLease<TResource> lease)
        {
            if (lease == null)
            {
                throw new ArgumentNullException(nameof(lease));
            }

            return new AcquisitionResult<TResource>(AcquisitionOutcome.Acquired, lease);
        }
    }
}
