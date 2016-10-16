﻿using System;
using System.Collections.Generic;

namespace api.winehunter.DbModels
{
    public partial class WineTypes
    {
        public WineTypes()
        {
            WineVarietyTyes = new HashSet<WineVarietyTyes>();
        }

        public int WineTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WineVarietyTyes> WineVarietyTyes { get; set; }
    }
}
