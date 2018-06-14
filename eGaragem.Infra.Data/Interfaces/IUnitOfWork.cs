using System;
using System.Data;

namespace eGarage.Infra.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool _hasConnection { get; set; }
        IDbTransaction _transaction { get; set; }
        IDbConnection _connection { get; set; }
        IDbCommand CreateCommand();
        void SaveChanges();
    }
}
