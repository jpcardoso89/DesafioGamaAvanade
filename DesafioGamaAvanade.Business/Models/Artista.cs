using DesafioGamaAvanade.Business.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Artista
    {
        public Guid ArtistaId { get; set; }
        public string Nome { get; set; }
        public decimal Cache { get; set; }
        public int Idade { get; set; }
        public List<Genero> Generos { get; set; }

        public Artista()
        {
            ArtistaId = Guid.NewGuid();
        }

        public Artista(string nome, decimal cache)
        {
            ArtistaId = Guid.NewGuid();
            Nome = nome;
            Cache = cache;
        }
    }
}
