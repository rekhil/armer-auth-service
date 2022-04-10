using System.ComponentModel.DataAnnotations;

namespace Armer.Auth.Service.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is mandatory")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
    }
}
