//using eGaragem.Infra.Data.Context;
using eGaragem.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool _hasConnection { get; set; }
        public IDbTransaction _transaction { get; set; }
        public IDbConnection _connection { get; set; }

        public UnitOfWork(IDbConnection connection, bool hasConnection)
        {
            _connection = connection;
            _hasConnection = hasConnection;
            _transaction = connection.BeginTransaction();
        }

        //cria objeto de comando
        public IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }

        //salva as alteraçoes, verificando se a transação é nula
        //após commitar a transacao, seta null para evitar probelma de concorrencia
        public void SaveChanges()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException(
                    "A transação já foi commitada.");
            }
            _transaction.Commit();
            _transaction = null;
        }

        //fecha a conexao, e caso tenha alguma transacao em uso, faz rollback
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
            if (_connection != null && _hasConnection)
            {
                _connection.Close();
                _connection = null;
            }
        }


    }
}
