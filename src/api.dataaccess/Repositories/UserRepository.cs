using api.dataaccess.CacheServices;
using api.dataaccess.Entities;
using api.dataaccess.Infrastructure;

namespace api.dataaccess.Repositories
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        public UserRepository(IConnectionFactory connectionFactory, ICacheProvider cacheProvider) : base(connectionFactory, cacheProvider)
        {
        }
    }
}
