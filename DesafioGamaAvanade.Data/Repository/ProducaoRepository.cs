using Dapper;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Data.Repository
{
    public class ProducaoRepository : IProducaoRepository
    {
        private readonly IConfiguration _configuration;
        public ProducaoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Producao> Add(Producao entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"INSERT INTO Producao Values(@ProducaoId, @Titulo, @DataInicialDasGravacoes, @Orcamento, @ProdutorId)", 
                        new { entity.Titulo, entity.DataInicialDasGravacoes, entity.Orcamento, entity.ProducaoId, entity.Produtor.ProdutorId });
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
                    var rowsAfected = await cn.ExecuteAsync(@"DELETE FROM Producao WHERE ProducaoId = @id", new { id });
                    cn.Close();
                    return rowsAfected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Producao> FindById(Guid id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var producao = await cn.QueryFirstOrDefaultAsync<Producao>(@"SELECT * FROM Producao WHERE ProducaoId = @id", new { id });
                    cn.Close();
                    return producao;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Producao>> ListAll()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var producao = await cn.QueryAsync<Producao>(@"SELECT * FROM Producao");
                    cn.Close();
                    return producao;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Producao> Update(Producao entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"UPDATE Producao SET Titulo = @Titulo, 
                            DataInicialDasGravacoes = @DataInicialDasGravacoes,
                            Orcamento = @Orcamento,
                            WHERE ProducaoId = @Id", new { entity.Titulo, entity.DataInicialDasGravacoes, entity.Orcamento, Id = entity.ProducaoId});
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
