using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models.Inputs
{
    public class ReservaInput
    {
        public Guid ProducaoId { get; set; }
        public Guid ArtistaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal CacheTotal { get; set; }
    }
}
