using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class ProdutorService : IProdutorService
    {
        private readonly IProdutorRepository _produtorRepository;
        private readonly ISmartNotification _notification;

        public ProdutorService(ISmartNotification notification, IProdutorRepository produtorRepository)
        {
            _produtorRepository = produtorRepository;
            _notification = notification;
        }

        public async Task<int> Delete(Guid id)
        {
            return await _produtorRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Produtor>> Get()
        {
            return await _produtorRepository.ListAll();
        }

        public async Task<Produtor> GetById(Guid id)
        {
            return await _produtorRepository.FindById(id);
        }

        public async Task<Produtor> Save(Produtor entity)
        {
            return await _produtorRepository.Add(entity);
        }

        public async Task<Produtor> Update(Produtor entity)
        {

            return await _produtorRepository.Update(entity);
        }
    }
}
