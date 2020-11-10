using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public Produtor Produtor { get; set; }
        public Artista Artista { get; set; }
        public DateTime DataDaReserva { get; set; }

        public Reserva()
        {
            Id = Guid.NewGuid();
        }
    }
}
