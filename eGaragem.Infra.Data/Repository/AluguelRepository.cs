using eGaragem.Domain.Entities;
using eGaragem.Domain.Interfaces.Repository;
using eGaragem.Infra.Data.Interfaces;
using eGaragem.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace eGaragem.Infra.Data.Repository
{
    public class AluguelRepository
    {
        private UnitOfWork _uow;
        public AluguelRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");

            _uow = uow as UnitOfWork;

            if (_uow == null)
                throw new NotSupportedException("UnityOfWork factory esta nulo.");
        }

        public bool Adicionar(Aluguel obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Insert Into Alugueis (AluguelId, LocatarioId, EnderecoId, UsuarioId, Inicio, Fim) Values" +
                    "(@AluguelId, @LocatarioId, @EnderecoId, @UsuarioId, @Inicio, @Fim)";

                SqlParameter[] parametros = new SqlParameter[6];
                parametros[0] = new SqlParameter() { Value = obj.AluguelId, ParameterName = "@AluguelId" };
                parametros[0] = new SqlParameter() { Value = obj.LocatarioId, ParameterName = "@LocatarioId" };
                parametros[0] = new SqlParameter() { Value = obj.EnderecoId, ParameterName = "@EnderecoId" };
                parametros[0] = new SqlParameter() { Value = obj.LocadorId, ParameterName = "@UsuarioId" };
                parametros[0] = new SqlParameter() { Value = obj.DataInicio, ParameterName = "@Inicio" };
                parametros[0] = new SqlParameter() { Value = obj.DataFim, ParameterName = "@Fim" };

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.Add(parametros[i]);
                }

                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }
        public bool Atualizar(Aluguel obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Update Alugueis Set AluguelId = @AluguelId, LocatarioId = @LocatarioId, EnderecoId = @EnderecoId, UsuarioId = @UsuarioId, Inicio = @Inicio, Fim = @Fim";

                SqlParameter[] parametros = new SqlParameter[6];
                parametros[0] = new SqlParameter() { Value = obj.AluguelId, ParameterName = "@AluguelId" };
                parametros[0] = new SqlParameter() { Value = obj.LocatarioId, ParameterName = "@LocatarioId" };
                parametros[0] = new SqlParameter() { Value = obj.EnderecoId, ParameterName = "@EnderecoId" };
                parametros[0] = new SqlParameter() { Value = obj.LocadorId, ParameterName = "@UsuarioId" };
                parametros[0] = new SqlParameter() { Value = obj.DataInicio, ParameterName = "@Inicio" };
                parametros[0] = new SqlParameter() { Value = obj.DataFim, ParameterName = "@Fim" };

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.Add(parametros[i]);
                }

                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }

        public Aluguel ObterPorId(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select AluguelId, LocatarioId, EnderecoId, UsuarioId, Inicio, Fim From Alugueis Where AluguelId = @AluguelId";
                SqlParameter param = new SqlParameter() { Value = id, ParameterName = "@AluguelId"};
                cmd.Parameters.Add(param);
                using (var reader = cmd.ExecuteReader())
                {
                    Aluguel aluguel = new Aluguel();
                    while (reader.Read())
                    {
                        aluguel.AluguelId = new Guid(reader["AluguelId"].ToString());
                        aluguel.LocatarioId = new Guid(reader["LocatarioId"].ToString());
                        aluguel.EnderecoId = new Guid(reader["EnderecoId"].ToString());
                        aluguel.LocadorId = new Guid(reader["UsuarioId"].ToString());
                        aluguel.DataInicio = Convert.ToDateTime(reader["Inicio"].ToString());
                        aluguel.DataFim = Convert.ToDateTime(reader["Fim"].ToString());
                    }
                    return aluguel;
                }
            }
        }

        public IEnumerable<Aluguel> ObterTodos()
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select AluguelId, LocatarioId, EnderecoId, UsuarioId, Inicio, Fim From Alugueis";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Aluguel aluguel = new Aluguel();
                        aluguel.AluguelId = new Guid(reader["AluguelId"].ToString());
                        aluguel.LocatarioId = new Guid(reader["LocatarioId"].ToString());
                        aluguel.EnderecoId = new Guid(reader["EnderecoId"].ToString());
                        aluguel.LocadorId = new Guid(reader["UsuarioId"].ToString());
                        aluguel.DataInicio = Convert.ToDateTime(reader["Inicio"].ToString());
                        aluguel.DataFim = Convert.ToDateTime(reader["Fim"].ToString());
                        yield return aluguel;
                    }
                }
            }
        }

        public bool Remover(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Delete From Alugueis where AluguelId = @AluguelId";
                SqlParameter parametro = new SqlParameter() { Value = id, ParameterName = "@AluguelId" };
                cmd.Parameters.Add(parametro);
                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;

            }
        }
    }
}
