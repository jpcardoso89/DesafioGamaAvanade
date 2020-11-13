using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGamaAvanade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        public GeneroController(IGeneroService generoService)
        {
            this._generoService = generoService;
        }

        [HttpPost]
        public async Task<ActionResult<Genero>> Adicionar(Genero genero)
        {
            await this._generoService.Save(genero);
            return Ok(genero);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> GetGenero(Guid id)
        {
            var genero = await _generoService.GetById(id).ConfigureAwait(false);
            return Ok(genero);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> GetAll()
        {
            var generos = await _generoService.Get().ConfigureAwait(false);
            return Ok(generos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Genero>> Delete(Guid id)
        {
            await this._generoService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Genero>> Update(Guid id, Genero genero)
        {
            if (id != genero.Id)
            {
                return BadRequest();
            }
            var generoAtualizado = await this._generoService.Update(genero);
            return Ok(generoAtualizado);
        }


    }
}
