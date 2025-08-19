using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class ApplicationUser
    {
        public Guid ID { get; set; }
        [Required, MaxLength(255)]
        public string Username { get; set; } = string.Empty;   
        [Required, MaxLength(255)]
        public string Password { get; set; } = string.Empty;
        [Required, MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public List<int> Ints { get; set; } = [];
    }
}
