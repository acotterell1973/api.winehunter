using System;
using api.dataaccess.Repositories;

namespace api.dataaccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IWineInfoRepository _wineInfoRepository;

        public UnitOfWork(IWineInfoRepository wineInfoRepository)
        {
            _wineInfoRepository = wineInfoRepository;
        }

        public IWineInfoRepository WineInfoRepository => _wineInfoRepository;
        public void Complete()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls



        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
