using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Interfaces
{
    public interface IService<TEntity>
    {
        Task<TEntity> Save(TEntity entity);
        Task<TEntity> Delete(Guid id);
        Task<TEntity> Update(TEntity entity);
    }
}
