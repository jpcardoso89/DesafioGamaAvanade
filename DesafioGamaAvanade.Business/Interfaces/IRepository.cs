using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task<TEntity> DeleteById(Guid id);
        Task<TEntity> FindById(Guid id);
        Task<TEntity> ListAll();
        Task<TEntity> Update(TEntity entity);

    }
}
