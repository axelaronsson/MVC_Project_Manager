using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;
public class UserSignInForm
{
    [Required(ErrorMessage = "Required field")]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Required field")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
