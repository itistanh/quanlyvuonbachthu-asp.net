using System.ComponentModel.DataAnnotations;

namespace PhamTheAnhKTPMK21B.Models
{
    public class HabitatAnimalViewModel
    {
        // habitat
        public string? AnimalName { get; set; }
        public string? Species { get; set; }
        public int Age { get; set; }
        //animal
        public string? HabitatName { get; set; }
        public string? Climate { get; set; }
        public double Area { get; set; }
    }
}
