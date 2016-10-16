using System;
using System.Collections.Generic;

namespace api.winehunter.Models
{
    public  class WineInfo
    {
        public int WineListId { get; set; }
        public string Upc { get; set; }
        public string VarietyName { get; set; }
        public string Producer { get; set; }
        public string Region { get; set; }
        public int Vintage { get; set; }
        public decimal Size { get; set; }
        public decimal AlchoholLevel { get; set; }
        public bool HasSulphites { get; set; }

    }
}
