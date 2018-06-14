using eGaragem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<Usuario>
    {
        Usuario ObterPorCpf(string cpf);
        Usuario ObterPorEmail(string email);
    }
}
