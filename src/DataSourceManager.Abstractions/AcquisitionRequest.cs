using System;

namespace Infoconex.DataSourceManager
{
    /// <summary>Identifies the requested provider and connection profile without carrying secrets.</summary>
    public sealed class AcquisitionRequest
    {
        /// <summary>Creates a request for an explicitly identified provider and profile.</summary>
        public AcquisitionRequest(string providerId, string profileId)
        {
            if (string.IsNullOrWhiteSpace(providerId))
            {
                throw new ArgumentException("A provider identifier is required.", nameof(providerId));
            }

            if (string.IsNullOrWhiteSpace(profileId))
            {
                throw new ArgumentException("A profile identifier is required.", nameof(profileId));
            }

            ProviderId = providerId;
            ProfileId = profileId;
        }

        /// <summary>Gets the explicit provider identifier. This is not a registration or authorization decision.</summary>
        public string ProviderId { get; }

        /// <summary>Gets the explicit profile identifier. This is not a caller identity or authorization grant.</summary>
        public string ProfileId { get; }
    }
}
