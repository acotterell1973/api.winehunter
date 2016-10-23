using System;

namespace api.dataaccess.Entities
{
    public class WineJournals
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string PlaceId { get; set; }
        public int WineListWineListId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual WineList WineListWineList { get; set; }
    }
}
