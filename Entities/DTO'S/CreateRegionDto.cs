﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_S
{
    public class CreateRegionDto
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";

        public string? ImageUrl { get; set; }
    }
}
