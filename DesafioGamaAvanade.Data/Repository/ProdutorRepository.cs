using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DesafioGamaAvanade.Data.Repository
{
    public class ProdutorRepository : IProdutorRepository
    {
        private readonly IConfiguration _configuration;
        public ProdutorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Produtor> Add(Produtor entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"INSERT INTO Produtor Values(NewID(), @Nome, @UserLogin)", new { Nome = entity.Nome, UserLogin = entity.User.Login });
                    cn.Close();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<int> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Produtor> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produtor>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Produtor> Update(Produtor entity)
        {
            throw new NotImplementedException();
        }
    }
}
