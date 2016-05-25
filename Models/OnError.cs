namespace Useful.Utilities.Models
{
    /// <summary>
    /// Windows Service Error reporting mode
    /// </summary>
    public enum OnError
    {
        UserIsNotNotified = 0,
        UserIsNotified = 1,
        SystemRestartedLastGoodConfiguraion = 2,
        SystemAttemptStartWithGoodConfiguration = 3
    }
}