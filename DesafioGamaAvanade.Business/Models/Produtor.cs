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
        public User User { get; set; }

        public Produtor()
        {
            ProdutorId = Guid.NewGuid();
        }

        public Produtor(string nome, User user)
        {
            ProdutorId = Guid.NewGuid();
            Nome = nome;
            User = user;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Nome))
            {
                valid = false;
            }

            return valid;
        }
    }
}
