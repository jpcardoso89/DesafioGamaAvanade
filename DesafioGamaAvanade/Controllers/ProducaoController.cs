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
    public class ProducaoController : ControllerBase
    {
        private readonly ILogger<ProducaoController> _logger;
        private readonly IProducaoService _producaoService;

        public ProducaoController(IProducaoService produtorService, ILogger<ProducaoController> logger)
        {
            _producaoService = produtorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Producao>> Get()
        {
            var producao = await this._producaoService.Get().ConfigureAwait(false);
            _logger.LogInformation("Poduções listadas");
            return producao;
        }

        [HttpPost]
        public async Task<ActionResult<Producao>> Adicionar(Producao producao)
        {
            var producaoSalva = await this._producaoService.Save(producao);
            _logger.LogInformation("Producao salva");
            return Ok(producaoSalva);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producao>> GetProducao(Guid id)
        {
            var producao = await this._producaoService.GetById(id).ConfigureAwait(false);
            return Ok(producao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Producao>> Update(Guid id, Producao producao)
        {
            if (id != producao.ProducaoId)
            {
                _logger.LogError("ProducaoId da url diferente do ProducaoId passado no body");
                return BadRequest();
            }
            var producaoAtualizado = await this._producaoService.Update(producao);
            return Ok(producaoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Producao>> Delete(Guid id)
        {
            await this._producaoService.Delete(id);
            _logger.LogInformation("Producao deletada");
            return Ok();
        }
        [HttpGet]
        [Route("producoes/{produtorId}")]
        public async Task<ActionResult<Producao>> ListarProducoes(Guid produtorId)
        {
            var producoes = await this._producaoService.ListProducaoByProdutorId(produtorId);
            return Ok(producoes);
        }
    }
}
