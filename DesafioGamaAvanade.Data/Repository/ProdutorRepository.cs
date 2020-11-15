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

        public async Task<int> DeleteById(Guid id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"DELETE FROM Reserva WHERE ProdutorId = @id", new { id });
                    await cn.ExecuteAsync(@"DELETE FROM Producao WHERE ProducaoId = @id", new { id });
                    var rowsAfected = await cn.ExecuteAsync(@"DELETE FROM Produtor WHERE ProdutorId = @id", new { id });
                    cn.Close();
                    return rowsAfected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produtor> FindById(Guid id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var produtor = await cn.QueryFirstOrDefaultAsync<Produtor>(@"SELECT * FROM Produtor WHERE ProdutorId = @id", new { id });
                    cn.Close();
                    return produtor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Produtor>> ListAll()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var produtor = await cn.QueryAsync<Produtor>(@"SELECT * FROM Produtor");
                    cn.Close();
                    return produtor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produtor> Update(Produtor entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"UPDATE Produtor SET Nome = @Nome WHERE ProdutorId = @ProdutorId", new { entity.Nome, entity.ProdutorId });
                    cn.Close();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
