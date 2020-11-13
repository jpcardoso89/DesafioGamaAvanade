using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class ArtistaService : IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly ISmartNotification _notification;

        public ArtistaService(ISmartNotification notification, IArtistaRepository artistaRepository)
        {
            _artistaRepository = artistaRepository;
            _notification = notification;
        }
        public async Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artista>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Artista> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Artista> Save(Artista entity)
        {
            return await _artistaRepository.Add(entity);
        }

        public async Task<Artista> Update(Artista entity)
        {
            throw new NotImplementedException();
        }
    }
}
