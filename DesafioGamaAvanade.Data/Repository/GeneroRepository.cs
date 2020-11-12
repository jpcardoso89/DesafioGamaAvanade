using DapperExtensions;
using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Data.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly IConfiguration _configuration;
        public GeneroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Genero> Add(Genero entity)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                cn.Open();
                Guid id = cn.Insert(entity);
                cn.Close();
                entity.Id = id;
                return entity;
            }
        }

        public Task<Genero> Delete(Genero entity)
        {
            throw new NotImplementedException();
        }

        public Task<Genero> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Genero> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Genero> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Genero> Update(Genero entity)
        {
            throw new NotImplementedException();
        }
    }
}
