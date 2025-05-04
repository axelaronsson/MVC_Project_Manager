using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class UserSignUpForm
{
    [Required(ErrorMessage ="Required field")]
    [Display(Name = "Full Name", Prompt = "Enter your full name")]
    [DataType(DataType.Text)]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Required field")]
    [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Invalid email")]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Required field")]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9 -]).{8,}$", ErrorMessage = "Password must be at least 8 characters and contain one: digit, lowercase and uppercase letter, non alphanumeric.")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Required field")]
    [Display(Name = "Confirm Password", Prompt = "Confirm your password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [Required(ErrorMessage = "Required field")]
    [Display(Name = "Terms & Conditions", Prompt = "I accept Terms & Conditions")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You need to approve the Terms & Condtitions")]
    public bool TermsAndConditions { get; set;}
}
