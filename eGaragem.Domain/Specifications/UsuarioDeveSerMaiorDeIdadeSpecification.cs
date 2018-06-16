using DomainValidation.Interfaces.Specification;
using eGaragem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Domain.Specifications
{
    public class UsuarioDeveSerMaiorDeIdadeSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return DateTime.Now.Year - usuario.DataNascimento.Year >= 18;
        }
    }
}
