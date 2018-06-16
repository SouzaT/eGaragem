using DomainValidation.Interfaces.Specification;
using eGaragem.Domain.Entities;
using eGaragem.Domain.Validations.Documents;

namespace eGaragem.Domain.Specifications
{
    public class UsuarioDeveTerCpfValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return CpfValidation.Validar(usuario.CPF);
        }
    }
}
