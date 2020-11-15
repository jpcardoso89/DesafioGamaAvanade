using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Producao
    {
        public Guid ProducaoId { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicialDasGravacoes { get; set; }
        public decimal Orcamento { get; set; }
        public Produtor Produtor { get; set; }
        public List<Artista> Artistas { get; set; }
        public Producao()
        {
            ProducaoId = Guid.NewGuid();
        }
    }
}
