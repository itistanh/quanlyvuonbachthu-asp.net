using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhamTheAnhKTPMK21B.Models
{
    public class Animal
    {
        //Animal (AnimalId, Name, Species, Age)
        [Key]
        public int AnimalId { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        public string? AnimalName { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        public string? Species { get; set; }
        [Required,Range(1,int.MaxValue)]
        public int Age { get; set; }
        [ForeignKey("HabitatId")]
        public int HabitatId { get; set; }
        public Habitat? Habitat { get; set; }
    }
}
