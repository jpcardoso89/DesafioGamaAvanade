using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Genero
    {
        public Guid GeneroId { get; set; }
        public string Nome { get; set; }

        public Genero()
        {
            GeneroId = Guid.NewGuid();
        }

        public Genero (string nome)
        {
            Nome = nome;
        }
    }
}
