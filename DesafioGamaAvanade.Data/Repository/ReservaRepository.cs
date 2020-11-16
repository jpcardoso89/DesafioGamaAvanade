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
    public class ReservaRepository : IReservaRepository
    {
        private readonly IConfiguration _configuration;
        public ReservaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Reserva> Add(Reserva entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"INSERT INTO Reserva Values(@ProducaoId, @ArtistaId, @DataInicio, @DataFim, @CacheTotal)"
                                        , new { entity.ProducaoId, entity.ArtistaId, entity.DataInicio, entity.DataFim, entity.CacheTotal });
                    cn.Close();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }

        public async Task<int> DeleteById(Guid id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var rowsAfected = await cn.ExecuteAsync(@"DELETE FROM Reserva WHERE ReservaId = @id", new { id });
                    cn.Close();
                    return rowsAfected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Reserva> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reserva>> ListAll()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var reserva = await cn.QueryAsync<Reserva, Artista, Producao, Reserva>(@"select r.ReservaId, r.DataInicio, r.DataFim, r.CacheTotal, p.ProdutorId, 
                                                                                             p.Titulo, a.ArtistaId, a.Nome 
                                                                                             FROM Reserva r
                                                                                             JOIN Produtoro p on p.ProdutorId = r.ProdutorId
                                                                                             JOIN Artista a on a.ArtistaId = r.ArtistaId", (reserva, artista, producao) => {
                        reserva.Producao = producao;
                        reserva.Artista = artista;
                        return reserva;
                    }, splitOn: "GeneroId,ArtistaId");
                    
                    return reserva;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Reserva> Update(Reserva entity)
        {
            throw new NotImplementedException();
        }
    }
}
