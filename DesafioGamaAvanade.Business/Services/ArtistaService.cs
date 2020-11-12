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
        public Task<Artista> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Artista>> Get()
        {
            var listaArtista = new List<Artista>();
            // listaArtista = await artistaRepository.ListAll();
            listaArtista.Add(new Artista("Reinaldo janequine", 1500));
            return listaArtista;
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
