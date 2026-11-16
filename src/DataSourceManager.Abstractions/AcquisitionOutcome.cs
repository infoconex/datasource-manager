namespace Infoconex.DataSourceManager
{
    /// <summary>Identifies an acquisition outcome without exposing provider or credential details.</summary>
    public enum AcquisitionOutcome
    {
        /// <summary>An authorized provider resource was acquired and returned in a managed lease.</summary>
        Acquired = 0,

        /// <summary>No explicitly registered provider can fulfill the request.</summary>
        UnsupportedProvider = 1,
    }
}
