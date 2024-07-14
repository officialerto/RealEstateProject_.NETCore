﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public bool Status { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual List<Neighborhood> Neighborhoods { get; set; }
    }
}
