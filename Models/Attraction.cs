using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Models
{
    public class Attraction
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string WorkingHours { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? EntranceFee { get; set; }
        
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City { get; set; } = null!;
    }
}