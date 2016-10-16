namespace api.winehunter.Models
{
    public interface IWineInfoRepository
    {
        WineInfo Find(string upc);
    }
}
