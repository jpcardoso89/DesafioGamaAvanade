using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Interfaces
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        Task<IEnumerable<Artista>> ListAllByFilter(PesquisaArtistaInput filter);
    }
}
