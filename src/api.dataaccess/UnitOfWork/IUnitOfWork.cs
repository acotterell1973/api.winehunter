using System;
using api.dataaccess.Repositories;

namespace api.dataaccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IWineInfoRepository WineInfoRepository { get; }
        void Commit();
    }
}