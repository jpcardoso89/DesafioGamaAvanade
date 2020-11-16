using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ISmartNotification _notification;

        public ReservaService(ISmartNotification notification, IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
            _notification = notification;
        }
        public async Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reserva>> Get()
        {
            return await _reservaRepository.ListAll();
        }

        public async Task<Reserva> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Reserva> Save(Reserva entity)
        {
            //var qtdDias = entity.DataFim - entity.DataInicio;
            //entity.CacheTotal = qtdDias.Days * entity.Artista.
            return await _reservaRepository.Add(entity);
        }

        public async Task<Reserva> Update(Reserva entity)
        {
            throw new NotImplementedException();
        }
    }
}
