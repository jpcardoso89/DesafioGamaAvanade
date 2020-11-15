using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> LoginAsync(string login, string password)
        {
            var user = await _userRepository
                                .GetByLoginAsync(login)
                                .ConfigureAwait(false);

            if (user == default)
            {
                // _notification.NewNotificationBadRequest("Usuário não encontrado!");
                return default;
            }

            if (!user.IsEqualPassword(password))
            {
                // _notification.NewNotificationBadRequest("Senha incorreta!");
                return default;
            }

            return new UserViewModel(user.Id, user.Login, user.Profile, user.Created);
        }
    }
}
