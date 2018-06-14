using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Domain.Entities
{
    public class Locatario : Usuario
    {
        public Locatario()
        {
            LocatarioId = new Guid();
            Enderecos = new List<Endereco>();
        }

        public Guid LocatarioId{ get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}
