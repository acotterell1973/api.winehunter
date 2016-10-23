using System;
using System.Collections.Generic;

namespace api.dataaccess.Entities
{
    public sealed class WineList
    {
        public WineList()
        {
            WineJournals = new HashSet<WineJournals>();
            WineRatings = new HashSet<WineRatings>();
        }

        public int WineListId { get; set; }
        public int WineVarietiesVarietyId { get; set; }
        public string Upc { get; set; }
        public string Producer { get; set; }
        public string Region { get; set; }
        public int Vintage { get; set; }
        public decimal? Size { get; set; }
        public decimal? AlchoholLevel { get; set; }
        public bool? HasSulphites { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<WineJournals> WineJournals { get; set; }
        public ICollection<WineRatings> WineRatings { get; set; }
        public WineVarieties WineVarietiesVariety { get; set; }
    }
}
