using System.ComponentModel.DataAnnotations;

namespace PrivateChat.Domains
{
    public class LoginCredentials
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
