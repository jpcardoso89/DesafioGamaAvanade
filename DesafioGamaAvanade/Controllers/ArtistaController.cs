using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioGamaAvanade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        
        private readonly ILogger<ArtistaController> _logger;
        private readonly IArtistaService _artistaService;

        public ArtistaController(IArtistaService artistaService, ILogger<ArtistaController> logger)
        {
            _artistaService = artistaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Artista>> Get()
        {
            var artistas = await this._artistaService.Get().ConfigureAwait(false);

            return artistas;
        }

        [HttpPost]
        public async Task<ActionResult<Artista>> Adicionar(Artista artista)
        {
            var artistaSalvo = await this._artistaService.Save(artista);
            return Ok(artistaSalvo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetArtista(Guid id)
        {
            var artista = await this._artistaService.GetById(id).ConfigureAwait(false);
            return Ok(artista);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Artista>> Update(Guid id, Artista artista)
        {
            if (id != artista.ArtistaId)
            {
                return BadRequest();
            }
            var artistaAtualizado = await this._artistaService.Update(artista);
            return Ok(artistaAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Artista>> Delete(Guid id)
        {
            await this._artistaService.Delete(id);
            return Ok();
        }

        


    }
}
