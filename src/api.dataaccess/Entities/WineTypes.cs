using System.Collections.Generic;

namespace api.dataaccess.Entities
{
    public sealed class WineTypes
    {
        public WineTypes()
        {
            WineVarietyTyes = new HashSet<WineVarietyTyes>();
        }

        public int WineTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<WineVarietyTyes> WineVarietyTyes { get; set; }
    }
}
