using System.ComponentModel.DataAnnotations;

namespace App.Carros.API.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password dont match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
