using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Models.Inputs;
using DesafioGamaAvanade.Business.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;

        public UserService(IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }
        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> InsertAsync(UserInput input)
        {
            var profile = await _profileRepository
                                    .GetByRole(input.Role)
                                    .ConfigureAwait(false);

            if (profile is null)
            {
                // _notification.NewNotificationBadRequest("Perfil associado não existe!");
                return default;
            }

            var user = new User(input.Login, input.Password, profile);

            if (!user.IsValid())
            {
                // _notification.NewNotificationBadRequest("Dados do usuário são obrigatórios");
                return default;
            }

            var id = await _userRepository
                            .InsertAsync(user)
                            .ConfigureAwait(false);

            return new UserViewModel ( new Guid(id), user.Login, user.Profile, user.Created );
        }

        public Task<User> Save(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
