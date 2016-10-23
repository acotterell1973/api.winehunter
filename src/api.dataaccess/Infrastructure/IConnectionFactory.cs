using System;
using System.Data;

namespace api.dataaccess.Infrastructure
{
    public interface IConnectionFactory: IDisposable
    {
        IDbConnection GetConnection { get;  }
    }
}
