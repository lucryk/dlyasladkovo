using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Region { get; set; } = string.Empty;
        
        public int Population { get; set; }
        public string History { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string CoatOfArmsPath { get; set; } = string.Empty;
        
        public List<Attraction> Attractions { get; set; } = new List<Attraction>();
    }
}