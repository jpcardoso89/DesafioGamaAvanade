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
    [Route("[controller]")]
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
    }
}
