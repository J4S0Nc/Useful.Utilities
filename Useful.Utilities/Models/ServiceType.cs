namespace Useful.Utilities.Models
{
    /// <summary>
    /// Type of Windows Service
    /// </summary>
    public enum ServiceType : uint
    {
        KernelDriver = 0x1,
        FileSystemDriver = 0x2,
        Adapter = 0x4,
        RecognizerDriver = 0x8,
        OwnProcess = 0x10,
        ShareProcess = 0x20,
        Interactive = 0x100
    }
}