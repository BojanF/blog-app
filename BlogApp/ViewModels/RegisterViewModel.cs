using System.ComponentModel.DataAnnotations;

namespace BlogApp.ViewModels
{
    public class RegisterViewModel {

        [Required, MaxLength(256), Display(Name = "Username")]
        public string Username { get; set; }

        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password) , Display(Name = "Password")]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password does not match the confirmartion password.")]
        public string ConfirmPassword { get; set; }

    }
}
