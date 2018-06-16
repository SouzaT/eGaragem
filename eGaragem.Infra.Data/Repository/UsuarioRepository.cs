using eGaragem.Domain.Entities;
using eGaragem.Domain.Interfaces.Repository;
using eGaragem.Infra.Data.Interfaces;
using eGaragem.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace eGaragem.Infra.Data.Repository
{
    public class UsuarioRepository
    {
        private UnitOfWork _uow;
        public UsuarioRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");

            _uow = uow as UnitOfWork;

            if (_uow == null)
            {
                throw new NotSupportedException("UnityOfWork factory está nulo.");
            }
        }

        public bool Adicionar(Usuario obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Insert into Usuarios(UsuarioId, AspNetUserId, Nome, Sobrenome, CPF, DataNascimento, DataCadastro, Ativo) Values " +
                    "(@UsuarioId, @AspNetUserId, @Nome, @Sobrenome, @Cpf, @DataNascimento, @DataCadastro, @Ativo)";

                SqlParameter[] parametros = new SqlParameter[8];
                parametros[0] = new SqlParameter() { Value = obj.Nome, ParameterName = "@Nome" };
                parametros[1] = new SqlParameter() { Value = obj.Sobrenome, ParameterName = "@Sobrenome" };
                parametros[2] = new SqlParameter() { Value = obj.Cpf, ParameterName = "@Cpf" };
                parametros[3] = new SqlParameter() { Value = obj.DataNascimento, ParameterName = "@DataNascimento" };
                parametros[4] = new SqlParameter() { Value = DateTime.Now, ParameterName = "@DataCadastro" };
                parametros[5] = new SqlParameter() { Value = true, ParameterName = "@Ativo" };
                parametros[6] = new SqlParameter() { Value = obj.UsuarioId, ParameterName = "@UsuarioId" };
                parametros[7] = new SqlParameter() { Value = obj.AspNetUserId, ParameterName = "@AspNetUserId" };

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.Add(parametros[i]);
                }

                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }

        public bool Atualizar(Usuario obj)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Update Usuarios set " +
                    "Nome = @Nome, Sobrenome = @Sobrenome, CPF = @Cpf, Email = @Email, DataNascimento = @DataNascimento, DataCadastro = @DataCadastro, Ativo = @Ativo";

                SqlParameter[] parametros = new SqlParameter[7];
                parametros[0] = new SqlParameter() { Value = obj.Nome, ParameterName = "@Nome" };
                parametros[1] = new SqlParameter() { Value = obj.Sobrenome, ParameterName = "@Sobrenome" };
                parametros[2] = new SqlParameter() { Value = obj.Cpf, ParameterName = "@Cpf" };
                parametros[3] = new SqlParameter() { Value = string.Empty, ParameterName = "@Email" };
                parametros[4] = new SqlParameter() { Value = obj.DataNascimento, ParameterName = "@DataNascimento" };
                parametros[5] = new SqlParameter() { Value = obj.DataCadastro, ParameterName = "@DataCadastro" };
                parametros[7] = new SqlParameter() { Value = obj.Ativo, ParameterName = "@Ativo" };

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.Add(parametros[i]);
                }

                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
            }
        }

        public Usuario ObterPorCpf(string cpf)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select UsuarioId, Nome, Sobrenome, CPF, Email, DataNascimento, DataCadastro, Ativo from Usuarios where Cpf = @Cpf";
                SqlParameter parametro = new SqlParameter() { Value = cpf, ParameterName = "@Cpf"};
                cmd.Parameters.Add(parametro);

                using (var reader = cmd.ExecuteReader())
                {
                    Usuario usuario = new Usuario();
                    while (reader.Read())
                    {
                        usuario.UsuarioId = new Guid(reader["UsuarioId"].ToString());
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Sobrenome = reader["Sobrenome"].ToString();
                        usuario.Cpf = reader["CPF"].ToString();
                        usuario.DataNascimento = Convert.ToDateTime(reader["DataNascimento"].ToString());
                        usuario.DataCadastro = Convert.ToDateTime(reader["DataCadastro"].ToString());
                        usuario.Ativo = Convert.ToBoolean(reader["Ativo"].ToString());
                    }
                    return usuario;
                }
            }
        }

        public Usuario ObterPorEmail(string email)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select UsuarioId, Nome, Sobrenome, CPF, Email, DataNascimento, DataCadastro, Ativo from Usuarios where Email = @Email";
                SqlParameter parametro = new SqlParameter() { Value = email, ParameterName = "@Email" };
                cmd.Parameters.Add(parametro);

                using (var reader = cmd.ExecuteReader())
                {
                    Usuario usuario = new Usuario();
                    while (reader.Read())
                    {
                        usuario.UsuarioId = new Guid(reader["UsuarioId"].ToString());
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Sobrenome = reader["Sobrenome"].ToString();
                        usuario.Cpf = reader["CPF"].ToString();
                        usuario.DataNascimento = Convert.ToDateTime(reader["DataNascimento"].ToString());
                        usuario.DataCadastro = Convert.ToDateTime(reader["DataCadastro"].ToString());
                        usuario.Ativo = Convert.ToBoolean(reader["Ativo"].ToString());
                    }
                    return usuario;
                }
            }
        }

        public Usuario ObterPorId(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select UsuarioId, Nome, Sobrenome, CPF, Email, DataNascimento, DataCadastro, Ativo from Usuarios where UsuarioId = @UsuarioId";
                SqlParameter parametro = new SqlParameter() { Value = id, ParameterName = "@UsuarioId" };
                cmd.Parameters.Add(parametro);

                using (var reader = cmd.ExecuteReader())
                {
                    Usuario usuario = new Usuario();
                    while (reader.Read())
                    {
                        usuario.UsuarioId = new Guid(reader["UsuarioId"].ToString());
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Sobrenome = reader["Sobrenome"].ToString();
                        usuario.Cpf = reader["CPF"].ToString();
                        usuario.DataNascimento = Convert.ToDateTime(reader["DataNascimento"].ToString());
                        usuario.DataCadastro = Convert.ToDateTime(reader["DataCadastro"].ToString());
                        usuario.Ativo = Convert.ToBoolean(reader["Ativo"].ToString());
                    }
                    return usuario;
                }
            }
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Select UsuarioId, Nome, Sobrenome, CPF, Email, DataNascimento, DataCadastro, Ativo from Usuarios";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.UsuarioId = new Guid(reader["UsuarioId"].ToString());
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Sobrenome = reader["Sobrenome"].ToString();
                        usuario.Cpf = reader["CPF"].ToString();
                        usuario.DataNascimento = Convert.ToDateTime(reader["DataNascimento"].ToString());
                        usuario.DataCadastro = Convert.ToDateTime(reader["DataCadastro"].ToString());
                        usuario.Ativo = Convert.ToBoolean(reader["Ativo"].ToString());
                        yield return usuario;
                    }
                }
            }
        }

        public bool Remover(Guid id)
        {
            using (var cmd = _uow.CreateCommand())
            {
                cmd.CommandText = "Delete From Usuarios where UsuarioId = @UsuarioId";
                SqlParameter parametro = new SqlParameter() { Value = id, ParameterName = "@UsuarioId" };
                cmd.Parameters.Add(parametro);
                bool success = cmd.ExecuteNonQuery() > 0;
                _uow.SaveChanges();
                return success;
                
            }
        }
    }
}
