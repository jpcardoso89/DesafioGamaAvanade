using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Models.Inputs;
using DesafioGamaAvanade.Business.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<object> InsertAsync(UserSaveInput input);
    }
}
