﻿using System;
using System.Collections.Generic;

namespace api.winehunter.DbModels
{
    public partial class WineVarietyTyes
    {
        public int WineVarietiesVarietyId { get; set; }
        public int WineTypesWineTypeId { get; set; }

        public virtual WineTypes WineTypesWineType { get; set; }
        public virtual WineVarieties WineVarietiesVariety { get; set; }
    }
}
