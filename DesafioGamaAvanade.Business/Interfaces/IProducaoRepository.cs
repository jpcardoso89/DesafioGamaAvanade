﻿using DesafioGamaAvanade.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Interfaces
{
    public interface IProducaoRepository : IRepository<Producao>
    {
        Task<IEnumerable<Producao>> ListProducaoByProdutorId(Guid produtorId);
    }
}
