using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Genero
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Genero()
        {
            Id = Guid.NewGuid();
        }
    }
}
