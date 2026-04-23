namespace CloudResourceManager.Models
{
    public class ManagedDatabase : CloudResource
    {
        public double StorageInGB { get; set; }
        public string DatabaseType { get; set; } = string.Empty;
    }
}
