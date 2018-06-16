using DomainValidation.Validation;
using eGaragem.Domain.Entities;
using eGaragem.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Domain.Validations
{
    public class UsuarioEstaConsistenteValidation : Validator<Usuario>
    {
        public UsuarioEstaConsistenteValidation()
        {
            var usuarioMaiorDeIdade = new UsuarioDeveSerMaiorDeIdadeSpecification();
            var CPFUsuario = new UsuarioDeveTerCpfValidoSpecification();

            base.Add("usuarioMarioIdade", new Rule<Usuario>(usuarioMaiorDeIdade, "Usuario não tem maioridade para cadastro."));
            base.Add("CPFUsuario", new Rule<Usuario>(CPFUsuario, "Usuário informou um CPF inválido."));
        }
    }
}
