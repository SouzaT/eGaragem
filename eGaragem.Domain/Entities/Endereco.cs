using System;

namespace eGaragem.Domain.Entities
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = new Guid();
        }
        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Guid LocatarioId { get; set; }
        


    }
}