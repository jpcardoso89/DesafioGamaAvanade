using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class ProducaoService : IProducaoService
    {
        private readonly IProducaoRepository _producaoRepository;
        private readonly ISmartNotification _notification;

        public ProducaoService(ISmartNotification notification, IProducaoRepository producaoRepositor)
        {
            _producaoRepository = producaoRepositor;
            _notification = notification;
        }

        public async Task<int> Delete(Guid id)
        {
            return await _producaoRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Producao>> Get()
        {
            return await _producaoRepository.ListAll();
        }

        public async Task<Producao> GetById(Guid id)
        {
            return await _producaoRepository.FindById(id);
        }

        public async Task<IEnumerable<Producao>> ListProducaoByProdutorId(Guid produtorId)
        {
            return await _producaoRepository.ListProducaoByProdutorId(produtorId);
        }

        public async Task<Producao> Save(Producao entity)
        {
            return await _producaoRepository.Add(entity);
        }

        public async Task<Producao> Update(Producao entity)
        {
            return await _producaoRepository.Update(entity);
        }
    }
}
