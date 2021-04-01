using System.ComponentModel.DataAnnotations;

namespace WebGloser.Model
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Error { get; set; }
    }
}