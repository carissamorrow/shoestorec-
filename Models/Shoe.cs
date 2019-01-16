using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
  public class Shoe
  {
    [Required]
    public string Name { get; set; }
    [Required]

    public string Description { get; set; }
    [Range(5, float.MaxValue)]
    public float Price { get; set; }
  }
}