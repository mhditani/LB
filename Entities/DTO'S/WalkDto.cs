using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_S
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        


        // Navigation Properties
        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
