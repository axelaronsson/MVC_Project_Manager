using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace WebApp.Models;

public class ProjectModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Required field")]
    [Display(Name = "Project Name", Prompt = "Project name")]
    [DataType(DataType.Text)]
    public string ProjectName { get; set; } = null!;

    [Required(ErrorMessage = "Required field")]
    [Display(Name = "Client Name", Prompt = "Client Name")]
    [DataType(DataType.Text)]
    public string Client {  get; set; } = null!;

    [Display(Name = "Description", Prompt = "Type something..")]
    [DataType(DataType.Text)]
    public string? Description { get; set; } = null!;

    //[Column(TypeName = "date")]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
    public DateTime StartDate { get; set; }

    //[Column(TypeName = "date")]
    [Display(Name = "End Date")]
    [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Display(Name = "Completed")]
    [Range(typeof(bool), "false", "true")]
    public bool Completed { get; set; }

    [RegularExpression(@"^\$?[0-9,\.]+", ErrorMessage = "Field must only contain digits, decimal points (optional) and currency symbol (optional).")]
    public string? Budget { get; set; }
}
