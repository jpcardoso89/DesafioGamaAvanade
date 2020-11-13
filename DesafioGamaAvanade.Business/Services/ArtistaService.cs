using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class ArtistaService : IArtistaService
    {
        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artista>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Artista> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Artista> Save(Artista entity)
        {
            throw new NotImplementedException();
        }

        public Task<Artista> Update(Artista entity)
        {
            throw new NotImplementedException();
        }
    }
}
