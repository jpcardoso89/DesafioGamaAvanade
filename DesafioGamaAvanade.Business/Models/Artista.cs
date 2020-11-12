using DesafioGamaAvanade.Business.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Artista
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Cache { get; set; }
        public int Idade { get; set; }
        public IEnumerable<Genero> Generos { get; set; }

        public Artista()
        {
            Id = Guid.NewGuid();
        }
    }
}
