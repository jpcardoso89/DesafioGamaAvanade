using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace DesafioGamaAvanade.Data.Repository
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly IConfiguration _configuration;
        public ArtistaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Artista> Add(Artista entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"INSERT INTO Artista Values(@Id, @Nome, @Cache, @Idade)", entity);
                    foreach (var genero in entity.Generos)
                    {
                        await cn.ExecuteAsync(@"INSERT INTO ArtistaGenero Values(@ArtistaId, @GeneroId)", new { ArtistaId = entity.Id, GeneroId = genero.Id });
                    }
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
            throw new NotImplementedException();
        }

        public async Task<Artista> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artista>> ListAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Artista> Update(Artista entity)
        {
            throw new NotImplementedException();
        }
    }
}
