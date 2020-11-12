using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroService(IGeneroRepository generoRepository)
        {
            var _generoRepository = generoRepository;
        }
        public Task<Genero> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genero>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Genero> Save(Genero entity)
        {
            await _generoRepository.Add(entity);
            return entity;
        }

        public Task<Genero> Update(Genero entity)
        {
            throw new NotImplementedException();
        }
    }
}
