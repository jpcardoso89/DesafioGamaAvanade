using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Add(TEntity entity);
        Task<int> DeleteById(Guid id);
        Task<TEntity> FindById(Guid id);
        Task<IEnumerable<TEntity>> ListAll();
        Task<TEntity> Update(TEntity entity);

    }
}
