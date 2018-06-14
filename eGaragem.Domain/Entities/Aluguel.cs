using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Domain.Entities
{
    public class Aluguel
    {
        public Aluguel()
        {
            AluguelId = new Guid();
        }
        public Guid AluguelId { get; set; }
        public Guid LocatarioId { get; set; }
        public Guid EnderecoId { get; set; }
        public Guid LocadorId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

    }
}
