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
using DesafioGamaAvanade.Business.Models.Inputs;

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
                    await cn.ExecuteAsync(@"INSERT INTO Artista Values(@ArtistaId, @Nome, @Cache, @Idade)", new { Nome = entity.Nome, Cache = entity.Cache, Idade = entity.Idade, ArtistaId = entity.ArtistaId});
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
                    await cn.ExecuteAsync(@"DELETE FROM ArtistaGenero WHERE ArtistaId = @id", new { id });
                    var rowsAfected = await cn.ExecuteAsync(@"DELETE FROM Artista WHERE ArtistaId = @id", new { id });
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
                    var artista = await cn.QueryAsync<Artista, Genero, Artista>(@"select a.ArtistaId, a.Nome, a.Idade, 
                                                                                    a.Cache, g.GeneroId, g.Nome 
                                                                                    from Artista a 
                                                                                    JOIN ArtistaGenero ag on ag.ArtistaId = a.ArtistaId 
                                                                                    JOIN Genero g on g.GeneroId = ag.GeneroId
                                                                                    WHERE a.ArtistaId = @id",(artista, genero) => {
                        artista.Generos = artista.Generos ?? new List<Genero>();
                        artista.Generos.Add(genero);
                        return artista;
                    }, splitOn: "GeneroId", param: new { id});
                    var result = artista.GroupBy(a => a.ArtistaId).Select(g =>
                    {
                        var groupedArtista = g.First();
                        groupedArtista.Generos = g.Select(p => p.Generos.Single()).ToList();
                        return groupedArtista;
                    });
                    cn.Close();
                    return result.Single();
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

        public async Task<IEnumerable<Artista>> ListAllByFilter(PesquisaArtistaInput filter)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var builder = new SqlBuilder();
                    var selector = builder.AddTemplate(@"select a.ArtistaId, a.Nome, a.Idade, a.Cache, g.GeneroId, g.Nome from Artista a JOIN ArtistaGenero ag on ag.ArtistaId = a.ArtistaId JOIN Genero g on g.GeneroId = ag.GeneroId LEFT JOIN Reserva r on r.ArtistaId = a.ArtistaId /**where**/");
                    if (filter.DataInicio.HasValue)
                    {
                        builder.Where("r.DataFim < @DataInicio", new { DataInicio = filter.DataInicio.Value });
                    }

                    if (filter.OrcamentoMaximo.HasValue)
                    {
                        builder.Where("a.Cache <= @OrcamentoMaximo", new { OrcamentoMaximo = filter.OrcamentoMaximo.Value });
                    }

                    cn.Open();
                    var artista = await cn.QueryAsync<Artista, Genero, Artista>(selector.RawSql, (artista, genero) => {
                        artista.Generos = artista.Generos ?? new List<Genero>();
                        artista.Generos.Add(genero);
                        return artista;
                    }, splitOn: "GeneroId", param: selector.Parameters);
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
                    await cn.ExecuteAsync(@"UPDATE Artista SET Nome = @Nome, Cache= @Cache, Idade = @Idade WHERE ArtistaId = @Id", new { entity.Nome, entity.Cache, entity.Idade, Id = entity.ArtistaId });
                    await cn.ExecuteAsync(@"DELETE FROM ArtistaGenero WHERE ArtistaId = @id", new { id = entity.ArtistaId });
                    foreach (var item in entity.Generos)
                    {
                        await cn.ExecuteAsync(@"INSERT INTO ArtistaGenero Values(@ArtistaId,@GeneroId)", new { entity.ArtistaId, item.GeneroId });
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
    }
}
