using System.ComponentModel.DataAnnotations;

namespace PhamTheAnhKTPMK21B.Models
{
    public class Habitat
    {
        //Habitat (HabitatId, Name, Climate, Area)
        [Key]
        public int HabitatId { get; set; }
        [Required,StringLength(200,MinimumLength =2)]
        public string? HabitatName { get; set; }
        [Required,StringLength(100, MinimumLength = 2)]
        public string? Climate { get; set; }
        [Required,Range(1,100)]
        public double Area { get; set; }
        public ICollection<Animal>? Animals { get; set; }

    }
}
