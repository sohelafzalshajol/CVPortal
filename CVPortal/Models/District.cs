﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class District
    {
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int IsActive { get; set; }
    }
}