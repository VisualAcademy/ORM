using System.ComponentModel.DataAnnotations;

namespace VisualAcademy.Models.Buffets;

//public class Sauce
//{
//    public int Id { get; set; }

//    public string? Name { get; set; }
//}

public class Sauce
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public bool IsVegan { get; set; }
}