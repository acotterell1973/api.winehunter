﻿using System;

namespace api.winehunter.Models
{
    public class WineList
    {
        public int WineListId { get; set; }
        public string UpcCode { get; set; }
        public int? WineCategoryId { get; set; }
        public string WineName { get; set; }
        public string Winery { get; set; }
        public string Varietal { get; set; }
        public string Region { get; set; }
        public int Year { get; set; }
        public int? Size { get; set; }
        public decimal? AlchoholLevel { get; set; }
        public string Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
