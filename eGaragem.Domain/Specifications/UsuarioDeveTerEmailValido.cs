using DomainValidation.Interfaces.Specification;
using eGaragem.Domain.Entities;
using eGaragem.Domain.Validations.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Domain.Specifications
{
    public class UsuarioDeveTerEmailValido : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return EmailValidation.Validate(usuario.Email);
        }
    }
}
