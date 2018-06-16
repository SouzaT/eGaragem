using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            UsuarioId = new Guid();
        }
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }

}
