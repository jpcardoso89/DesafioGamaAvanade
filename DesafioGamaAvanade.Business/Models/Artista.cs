using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Artista
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorDaAtuacao { get; set; }

        public Artista()
        {
            Id = Guid.NewGuid();
        }

        public Artista(string nome, decimal valorDaAtuacao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            ValorDaAtuacao = valorDaAtuacao;
        }
    }
}
