using eGaragem.Domain.Entities;
using eGaragem.Domain.Interfaces.Repository;
//using eGaragem.Infra.Data.Context;
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
    public class EnderecoRepository
    {
        private UnitOfWork _uow;

        public EnderecoRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");

            _uow = uow as UnitOfWork;

            if (_uow == null)
                throw new NotSupportedException("UnitOfWork factory está nulo.");
        }

        public bool Adicionar(Endereco obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Insert into Enderecos(EnderecoId, LocatarioId, Logradouro, Numero, Complemento, Cidade, Estado, Cep, Latitude, Longitude) values " +
                    "(@EnderecoId, @LocatarioId, @Logradouro, @Numero, @Complemento, @Cidade, @Estado, @Cep, @Latitude, @Longitude)";

                SqlParameter[] parametros = new SqlParameter[10];
                parametros[0] = new SqlParameter() { Value = obj.EnderecoId, ParameterName = "@EnderecoId" };
                parametros[1] = new SqlParameter() { Value = obj.LocatarioId, ParameterName = "@LocatarioId" };
                parametros[2] = new SqlParameter() { Value = obj.Logradouro, ParameterName = "@Logradouro" };
                parametros[3] = new SqlParameter() { Value = obj.Numero, ParameterName = "@Numero" };
                parametros[4] = new SqlParameter() { Value = obj.Complemento, ParameterName = "@Complemento" };
                parametros[5] = new SqlParameter() { Value = obj.Cidade, ParameterName = "@Cidade" };
                parametros[6] = new SqlParameter() { Value = obj.Estado, ParameterName = "@Estado" };
                parametros[7] = new SqlParameter() { Value = obj.Cep, ParameterName = "@Cep" };
                parametros[8] = new SqlParameter() { Value = obj.Latitude, ParameterName = "@Latitude" };
                parametros[9] = new SqlParameter() { Value = obj.Longitude, ParameterName = "@Longitude" };

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.Add(parametros[i]);
                }

                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }

        public bool Atualizar(Endereco obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Update Enderecos set EnderecoId = @EnderecoId, LocatarioId = @LocatarioId, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, " +
                    "Cidade = @Cidade, Estado = @Estado, Cep = @Cep, Latitude = @Latitide, Longitude = @Longitude";

                SqlParameter[] parametros = new SqlParameter[10];
                parametros[0] = new SqlParameter() { Value = obj.EnderecoId, ParameterName = "@EnderecoId" };
                parametros[1] = new SqlParameter() { Value = obj.LocatarioId, ParameterName = "@LocatarioId" };
                parametros[2] = new SqlParameter() { Value = obj.Logradouro, ParameterName = "@Logradouro" };
                parametros[3] = new SqlParameter() { Value = obj.Numero, ParameterName = "@Numero" };
                parametros[4] = new SqlParameter() { Value = obj.Complemento, ParameterName = "@Complemento" };
                parametros[5] = new SqlParameter() { Value = obj.Cidade, ParameterName = "@Cidade" };
                parametros[6] = new SqlParameter() { Value = obj.Estado, ParameterName = "@Estado" };
                parametros[7] = new SqlParameter() { Value = obj.Cep, ParameterName = "@Cep" };
                parametros[8] = new SqlParameter() { Value = obj.Latitude, ParameterName = "@Latitude" };
                parametros[9] = new SqlParameter() { Value = obj.Longitude, ParameterName = "@Longitude" };

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.Add(parametros[i]);
                }

                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }

        public Endereco ObterPorId(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select EnderecoId, LocatarioId, Logradouro, Numero, Complemento, Cidade, Estado, Cep, Latitude, Longitude Where EnderecoId = @EnderecoId";
                SqlParameter param = new SqlParameter() { Value = id, ParameterName = "@EnderecoId" };

                using (var reader = cmd.ExecuteReader())
                {
                    Endereco endereco = new Endereco();
                    while (reader.Read())
                    {
                        endereco.EnderecoId = new Guid(reader["EnderecoId"].ToString());
                        endereco.LocatarioId = new Guid(reader["LocatarioId"].ToString());
                        endereco.Logradouro = reader["Logradouro"].ToString();
                        endereco.Numero = reader["Numero"].ToString();
                        endereco.Complemento = reader["Complemento"].ToString();
                        endereco.Cidade = reader["Cidade"].ToString();
                        endereco.Estado = reader["Estado"].ToString();
                        endereco.Cep = reader["Cep"].ToString();
                        endereco.Latitude = Convert.ToDecimal(reader["Latitude"].ToString());
                        endereco.Longitude = Convert.ToDecimal(reader["Longitude"].ToString());
                    }
                    return endereco;
                }
            }
        }

        public Endereco ObterPorLocatario(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select EnderecoId, LocatarioId, Logradouro, Numero, Complemento, Cidade, Estado, Cep, Latitude, Longitude Where LocatarioId = @LocatarioId";
                SqlParameter param = new SqlParameter() { Value = id, ParameterName = "@LocatarioId" };

                using (var reader = cmd.ExecuteReader())
                {
                    Endereco endereco = new Endereco();
                    while (reader.Read())
                    {
                        endereco.EnderecoId = new Guid(reader["EnderecoId"].ToString());
                        endereco.LocatarioId = new Guid(reader["LocatarioId"].ToString());
                        endereco.Logradouro = reader["Logradouro"].ToString();
                        endereco.Numero = reader["Numero"].ToString();
                        endereco.Complemento = reader["Complemento"].ToString();
                        endereco.Cidade = reader["Cidade"].ToString();
                        endereco.Estado = reader["Estado"].ToString();
                        endereco.Cep = reader["Cep"].ToString();
                        endereco.Latitude = Convert.ToDecimal(reader["Latitude"].ToString());
                        endereco.Longitude = Convert.ToDecimal(reader["Longitude"].ToString());
                    }
                    return endereco;
                }
            }
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select EnderecoId, LocatarioId, Logradouro, Numero, Complemento, Cidade, Estado, Cep, Latitude, Longitude From Enderecos";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Endereco endereco = new Endereco();
                        endereco.EnderecoId = new Guid(reader["EnderecoId"].ToString());
                        endereco.LocatarioId = new Guid(reader["LocatarioId"].ToString());
                        endereco.Logradouro = reader["Logradouro"].ToString();
                        endereco.Numero = reader["Numero"].ToString();
                        endereco.Complemento = reader["Complemento"].ToString();
                        endereco.Cidade = reader["Cidade"].ToString();
                        endereco.Estado = reader["Estado"].ToString();
                        endereco.Cep = reader["Cep"].ToString();
                        endereco.Latitude = Convert.ToDecimal(reader["Latitude"].ToString());
                        endereco.Longitude = Convert.ToDecimal(reader["Longitude"].ToString());
                        yield return endereco;
                    }
                }
            }
        }

        public bool Remover(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Delete From Enderecos where EnderecoId = @EnderecoId";
                SqlParameter parametro = new SqlParameter() { Value = id, ParameterName = "@EnderecoId" };
                cmd.Parameters.Add(parametro);
                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;

            }
        }
    }
}
