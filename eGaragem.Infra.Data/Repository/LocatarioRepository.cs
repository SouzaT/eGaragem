using eGaragem.Domain.Entities;
using eGaragem.Domain.Interfaces.Repository;
using eGaragem.Infra.Data.Interfaces;
using eGaragem.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Infra.Data.Repository
{
    public class LocatarioRepository : IRepository<Locatario>, ILocatarioRepository
    {
        private UnitOfWork _uow;
        public LocatarioRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");

            _uow = uow as UnitOfWork;

            if (_uow == null)
                throw new NotSupportedException("UnityOfWork factory esta nulo.");
        }
        public bool Adicionar(Locatario obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Insert into Locatarios (LocatarioId, UsuarioId) Values (@LocatarioId, @UsuarioId)";
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter() { Value = obj.LocatarioId, ParameterName = "@LocatarioId"};
                parameters[1] = new SqlParameter() { Value = obj.UsuarioId, ParameterName = "@UsuarioId" };

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(parameters[i]);
                }
                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }

        public bool Atualizar(Locatario obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Update Locatarios Set LocatarioId = @LocatarioId, UsuarioId = @UsuarioId";
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter() { Value = obj.LocatarioId, ParameterName = "@LocatarioId" };
                parameters[1] = new SqlParameter() { Value = obj.UsuarioId, ParameterName = "@UsuarioId" };

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.Add(parameters[i]);
                }
                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }

        public Locatario ObterPorId(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select LocatarioId, UsuarioId from Locatarios where LocatarioId = @LocatarioId";
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter() { Value = id, ParameterName = "@LocatarioId" };
                using (var reader = cmd.ExecuteReader())
                {
                    Locatario locatario = new Locatario();
                    while (reader.Read())
                    {
                        locatario.LocatarioId = new Guid(reader["LocatarioId"].ToString());
                        locatario.UsuarioId = new Guid(reader["UsuarioId"].ToString());
                    }
                    return locatario;
                }
            }
        }

        public IEnumerable<Locatario> ObterTodos()
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select LocatarioId, UsuarioId from Locatarios";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Locatario locatario = new Locatario();
                        locatario.LocatarioId = new Guid(reader["LocatarioId"].ToString());
                        locatario.UsuarioId = new Guid(reader["UsuarioId"].ToString());
                        yield return locatario;
                    }
                }
            }
        }

        public bool Remover(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Delete From Locatarios where LocatarioId = @LocatarioId";
                SqlParameter parametro = new SqlParameter() { Value = id, ParameterName = "@LocatarioId" };
                cmd.Parameters.Add(parametro);
                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;

            }
        }
    }
}
