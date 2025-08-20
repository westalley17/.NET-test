namespace test.Models
{
    public class Wedding : ModelBase
    {
        public long Id { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Geolocation { get; set; } = string.Empty;
        public int GuestCount { get; set; }
    }
}
