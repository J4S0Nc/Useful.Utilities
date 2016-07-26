namespace Useful.Utilities.Models
{
    /// <summary>
    /// Windows Service  state
    /// </summary>
    public enum ServiceState
    {
        Running,
        Stopped,
        Paused,
        StartPending,
        StopPending,
        PausePending,
        ContinuePending
    }
}