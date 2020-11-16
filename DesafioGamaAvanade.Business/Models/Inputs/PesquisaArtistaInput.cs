using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models.Inputs
{
    public class PesquisaArtistaInput
    {
        public Guid GeneroId { get; set; }
        public DateTime? DataInicio { get; set; }
        public decimal? OrcamentoMaximo { get; set; }

    }
}
