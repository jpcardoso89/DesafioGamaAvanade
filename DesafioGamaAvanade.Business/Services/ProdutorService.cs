using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class ProdutorService : IProdutorService
    {
        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produtor>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Produtor> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Produtor> Save(Produtor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Produtor> Update(Produtor entity)
        {
            throw new NotImplementedException();
        }
    }
}
