namespace test.Models
{
    public abstract class ModelBase
    {
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedUser { get; set; } = string.Empty;
    }
}
