﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalFoodWebUI.Dtos.ContactDtos
{
	public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string? Location { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }

        public string? FooterDescription { get; set; }
    }
}
