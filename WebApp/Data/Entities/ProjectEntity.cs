using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string Client { get; set; } = null!;

    public string? Description { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    public bool Completed { get; set; }

    public string? Budget { get; set; }
}
