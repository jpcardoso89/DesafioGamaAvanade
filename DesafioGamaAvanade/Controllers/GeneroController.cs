using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGamaAvanade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : BaseController
    {
        private readonly IGeneroService _generoService;
        public GeneroController(INotificationHandler<DomainNotification> notification, IGeneroService generoService) : base(notification)
        {
            this._generoService = generoService;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Genero genero)
        {
            var generoSalvo = await this._generoService.Save(genero);
            return CreatedContent("", generoSalvo);
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
            if (id != genero.GeneroId)
            {
                return BadRequest();
            }
            var generoAtualizado = await this._generoService.Update(genero);
            return Ok(generoAtualizado);
        }


    }
}
