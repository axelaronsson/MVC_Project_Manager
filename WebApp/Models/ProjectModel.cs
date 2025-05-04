using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public class ProjectModel
{
    [Key]
    public int Id { get; set; }

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
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
    public DateTime StartDate { get; set; }

    //[Column(TypeName = "date")]
    [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Display(Name = "Completed")]
    [Range(typeof(bool), "false", "true")]
    public bool Completed { get; set; }

    public int Budget { get; set; }
}
