using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioGamaAvanade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutorController : ControllerBase
    {
        private readonly ILogger<ProdutorController> _logger;
        private readonly IProdutorService _produtorService;

        public ProdutorController(IProdutorService produtorService, ILogger<ProdutorController> logger)
        {
            _produtorService = produtorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Produtor>> Get()
        {
            var artistas = await this._produtorService.Get().ConfigureAwait(false);

            return artistas;
        }

        [HttpPost]
        public async Task<ActionResult<Produtor>> Adicionar(Produtor artista)
        {
            var artistaSalvo = await this._produtorService.Save(artista);
            return Ok(artistaSalvo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtor>> GetArtista(Guid id)
        {
            var artista = await this._produtorService.GetById(id).ConfigureAwait(false);
            return Ok(artista);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produtor>> Update(Guid id, Produtor produtor)
        {
            if (id != produtor.ProdutorId)
            {
                return BadRequest();
            }
            var produtorAtualizado = await this._produtorService.Update(produtor);
            return Ok(produtorAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produtor>> Delete(Guid id)
        {
            await this._produtorService.Delete(id);
            return Ok();
        }

        
    }
}
