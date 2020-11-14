using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Produtor
    {
        public Guid ProdutorId { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Reserva> Reservas { get; set; }

        public Produtor()
        {
            ProdutorId = Guid.NewGuid();
        }
    }
}
