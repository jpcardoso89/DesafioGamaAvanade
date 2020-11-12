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
    }
}
