namespace api.dataaccess.Entities
{
    public sealed class WineInfo
    {
        public int WineListId { get; set; }
        public string Upc { get; set; }
        public string VarietyName { get; set; }
        public string Variety { get; set; }
        public string Producer { get; set; }
        public string Region { get; set; }
        public int Vintage { get; set; }
        public decimal Size { get; set; }
        public decimal AlchoholLevel { get; set; }
        public bool HasSulphites { get; set; }

        public string ImageSource => $"https://winehunter.blob.core.windows.net/wine-bottles/{Upc}";
    }
}
