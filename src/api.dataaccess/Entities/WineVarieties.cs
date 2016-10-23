using System.Collections.Generic;

namespace api.dataaccess.Entities
{
    public sealed class WineVarieties
    {
        public WineVarieties()
        {
            WineList = new HashSet<WineList>();
            WineVarietyTyes = new HashSet<WineVarietyTyes>();
        }

        public int VarietyId { get; set; }
        public string Name { get; set; }

        public ICollection<WineList> WineList { get; set; }
        public ICollection<WineVarietyTyes> WineVarietyTyes { get; set; }
    }
}
