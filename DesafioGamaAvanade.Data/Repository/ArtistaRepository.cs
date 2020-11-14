using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using DesafioGamaAvanade.Business.DTO;
using System.Linq;

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
                    await cn.ExecuteAsync(@"INSERT INTO Artista Values(@ArtistaId, @Nome, @Cache, @Idade)", entity);
                    foreach (var genero in entity.Generos)
                    {
                        await cn.ExecuteAsync(@"INSERT INTO ArtistaGenero Values(@ArtistaId, @GeneroId)", new { ArtistaId = entity.ArtistaId, GeneroId = genero.GeneroId });
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
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var rowsAfected = await cn.ExecuteAsync(@"DELETE FROM Artista WHERE Id = @id", new { id });
                    cn.Close();
                    return rowsAfected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Artista> FindById(Guid id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var artista = await cn.QueryFirstOrDefaultAsync<Artista>(@"SELECT * FROM Artista WHERE Id = @id", new { id });
                    var artistasGeneros = await cn.QueryAsync<ArtistaGeneroDTO>(@"SELECT * FROM from ArtistaGenero ag 
                                                                                  JOIN Genero g ON g.Id = ag.GeneroId WHERE ag.ArtistaId = @id", new { id });
                    foreach (var artistaGenero in artistasGeneros)
                    {
                        artista.Generos.Add(artistaGenero.Genero);
                    }
                    cn.Close();
                    return artista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Artista>> ListAll()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    var artista = await cn.QueryAsync<Artista,Genero,Artista>(@"select a.ArtistaId, a.Nome, a.Idade, 
                                                                                    a.Cache, g.GeneroId, g.Nome 
                                                                                    from Artista a 
                                                                                    JOIN ArtistaGenero ag on ag.ArtistaId = a.ArtistaId 
                                                                                    JOIN Genero g on g.GeneroId = ag.GeneroId", (artista, genero) => {
                        artista.Generos = artista.Generos ?? new List<Genero>();
                        artista.Generos.Add(genero);
                        return artista;
                    }, splitOn: "GeneroId");
                    var result = artista.GroupBy(a => a.ArtistaId).Select(g =>
                    {
                        var groupedArtista = g.First();
                        groupedArtista.Generos = g.Select(p => p.Generos.Single()).ToList();
                        return groupedArtista;
                    });
                    cn.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Artista> Update(Artista entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    cn.Open();
                    await cn.ExecuteAsync(@"UPDATE Artista SET Nome = @Nome, Cache= @Cache, Idade = @Idade WHERE Id = @Id", new { entity.Nome, entity.Cache, entity.Idade, entity.ArtistaId });
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
