using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Models.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioGamaAvanade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ILogger<ReservaController> _logger;
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService, ILogger<ReservaController> logger)
        {
            _reservaService = reservaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> Get()
        {
            var reservas = await this._reservaService.Get().ConfigureAwait(false);
            return Ok(reservas);
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> Adicionar(Reserva reserva)
        {
           
            var reservaSalvo = await this._reservaService.Save(reserva);
            return Ok(reservaSalvo);
        }
    }
}
