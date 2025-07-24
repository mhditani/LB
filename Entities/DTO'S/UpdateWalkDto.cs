using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_S
{
    public class UpdateWalkDto
    {
        [Required, MaxLength(100, ErrorMessage = "Name has to be a maximim of 100 characters")]
        public string Name { get; set; } = "";
        [Required, MaxLength(100, ErrorMessage = "Description has to be a maximum of 100 characters")]
        public string Description { get; set; } = "";
        [Required, Range(0, 50, ErrorMessage = "Range must be between 0 to 50 km")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }

        
    }
}
