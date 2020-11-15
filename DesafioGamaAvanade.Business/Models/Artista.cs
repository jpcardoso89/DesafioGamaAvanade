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
        public User User { get; set; }

        public Artista()
        {
            ArtistaId = Guid.NewGuid();
        }

        public Artista(string nome, int idade, decimal cache, User user, List<Genero> generos)
        {
            ArtistaId = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
            Cache = cache;
            User = user;
            Generos = generos;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Nome) ||
                Cache < 0)
            {
                valid = false;
            }

            return valid;
        }
    }
}
