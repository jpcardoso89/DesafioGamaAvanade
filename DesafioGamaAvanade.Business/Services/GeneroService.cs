using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly ISmartNotification _notification;

        public GeneroService(ISmartNotification notification,IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
            _notification = notification;
        }
        public async Task<int> Delete(Guid id)
        {
            return await _generoRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Genero>> Get()
        {
            return await _generoRepository.ListAll();
        }

        public async Task<Genero> GetById(Guid id)
        {
            return await _generoRepository.FindById(id) ;
        }

        public async Task<Genero> Save(Genero entity)
        {
            if (string.IsNullOrEmpty(entity.Nome))
            {
                _notification.NewNotificationBadRequest("Nome do genero é obrigatório!");
                return default;
            }
            await _generoRepository.Add(entity);
            return entity;
        }

        public async Task<Genero> Update(Genero entity)
        {
            return await _generoRepository.Update(entity);
        }
    }
}
