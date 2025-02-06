using System.ComponentModel.DataAnnotations;

namespace MyBus.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password length should be (8-40) character long")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Password doesn't match, Please check again")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your password again")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]

        public string ConfirmPassword { get; set; }
    }
}
