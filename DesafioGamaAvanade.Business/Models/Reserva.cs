using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Reserva
    {
        public Guid ReservaId { get; set; }
        public Produtor Produtor { get; set; }
        public Artista Artista { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal CacheTotal { get; set; }

        public Reserva()
        {
            ReservaId = Guid.NewGuid();
        }
    }
}
