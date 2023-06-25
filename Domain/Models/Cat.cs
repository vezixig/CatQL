namespace Core.Models;

using System.ComponentModel.DataAnnotations;

public class Cat
{
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Color { get; set; } = string.Empty;

    public float Weight { get; set; }

    public DateTime Birthdate { get; set; }
}