﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLater.FeatureDto
{
    public class GetFeatureDto
    {
        public int FeatureId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
