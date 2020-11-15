using DesafioGamaAvanade.Business.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Interfaces
{
    public interface ILoginService
    {
        Task<UserViewModel> LoginAsync(string login, string password);
    }
}
