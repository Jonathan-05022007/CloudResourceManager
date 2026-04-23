namespace CloudResourceManager.Models
{
    public class VirtualMachine : CloudResource
    {
        public string OperatingSystem { get; set; } = string.Empty;
        public int RamInGB { get; set; }
    }
}
