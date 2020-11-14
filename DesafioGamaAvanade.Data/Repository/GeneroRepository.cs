using Dapper;
using DapperExtensions;
using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"INSERT INTO Genero Values(@GeneroId, @Nome)", entity);
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
                    var rowsAfected = await cn.ExecuteAsync(@"DELETE FROM Genero WHERE GeneroId = @id", new { id });
                    cn.Close();
                    return rowsAfected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Genero> FindById(Guid id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var genero = await cn.QueryFirstOrDefaultAsync<Genero>(@"SELECT * FROM Genero WHERE GeneroId = @id", new { id });
                    cn.Close();
                    return genero;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Genero>> ListAll()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var generos = await cn.QueryAsync<Genero>(@"SELECT * FROM Genero");
                    cn.Close();
                    return generos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Genero> Update(Genero entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"UPDATE Genero SET Nome = @Nome WHERE GeneroId = @Id", new { entity.Nome, entity.GeneroId });
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
