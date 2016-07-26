namespace Useful.Utilities.Models
{
    public enum DomainRole : uint
    {
        StandaloneWorkstation = 0x0,
        MemberWorkstation = 0x1,
        StandaloneServer = 0x2,
        MemberServer = 0x3,
        BackupDomainController = 0x4,
        PrimaryDomainController = 0x5

    }
}