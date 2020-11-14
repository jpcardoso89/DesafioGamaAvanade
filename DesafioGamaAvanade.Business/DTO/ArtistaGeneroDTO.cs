using DesafioGamaAvanade.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.DTO
{
    public class ArtistaGeneroDTO
    {
        public Guid ArtistaId { get; set; }
        public Artista Artista { get; set; }
        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
