using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Data.Repository
{
    public class ArtistaRepository : IArtistaRepository
    {
        public Task<Artista> Add(Artista entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Artista> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artista>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Artista> Update(Artista entity)
        {
            throw new NotImplementedException();
        }
    }
}
