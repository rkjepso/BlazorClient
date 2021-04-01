using System.ComponentModel.DataAnnotations;

namespace WebGloser.Model
{
    public class AddUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The User field must be a minimum of 3 characters")]
        public string Username { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The Password field must be a minimum of 3 characters")]
        public string Password { get; set; }
        public string Error { get; set; }
    }
}