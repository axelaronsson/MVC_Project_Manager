using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Client {  get; set; } = null!;
    public string Description { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    public string Status { get; set; } = null!;

    public int Budget { get; set; }
}
