using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VisualAcademy.Models.Buffets;

//public class Topping
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//}

public class Topping
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public decimal Calories { get; set; }

    [JsonIgnore]
    public ICollection<Pizza>? Pizzas { get; set; }
}
