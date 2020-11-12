using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Produtor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Reserva> Reservas { get; set; }
    }
}
