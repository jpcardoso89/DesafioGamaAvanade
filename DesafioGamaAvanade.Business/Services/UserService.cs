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
        private readonly IArtistaRepository _artistaRepository;
        private readonly IProdutorRepository _produtorRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IGeneroRepository _generoRepository;

        public UserService(IUserRepository userRepository,
            IArtistaRepository artistaRepository,
            IProdutorRepository produtorRepository,
            IProfileRepository profileRepository,
            IGeneroRepository generoRepository)
        {
            _userRepository = userRepository;
            _artistaRepository = artistaRepository;
            _produtorRepository = produtorRepository;
            _profileRepository = profileRepository;
            _generoRepository = generoRepository;
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

        public async Task<object> InsertAsync(UserSaveInput input)
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

            // Insere o usuário de autenticação
            var id = await _userRepository
                            .InsertAsync(user)
                            .ConfigureAwait(false);

            if (profile.Description == "ARTISTA")
            {
                var generos = new List<Genero>();
                foreach (var generoId in input.Generos)
                {
                    var genero = await _generoRepository
                                        .FindById(new Guid(generoId))
                                        .ConfigureAwait(false);
                    generos.Add(genero);
                }
                var artista = new Artista(input.Name, input.Idade,
                                            input.Cache, new User(input.Login, input.Password, profile),
                                            generos);
                
                if (!artista.IsValid())
                {
                    // _notification.NewNotificationBadRequest("Dados do usuário são obrigatórios");
                }

                var artistaId = await _artistaRepository
                                        .Add(artista)
                                        .ConfigureAwait(false);

                return new { id, user.Login, Profile = user.Profile.Description, user.Created, artista.Nome, artista.Cache, artista.Idade, artista.Generos };

            } else if (profile.Description == "PRODUTOR")
            {
                var produtor = new Produtor(input.Name, new User(input.Login, input.Password, profile));

                if (!produtor.IsValid())
                {
                    // _notification.NewNotificationBadRequest("Dados do usuário são obrigatórios");
                }

                var artistaId = await _produtorRepository
                                        .Add(produtor)
                                        .ConfigureAwait(false);
                return new { id, user.Login, Profile = user.Profile.Description, user.Created, produtor.Nome, produtor.Reservas };
            }

            return new { erro = "Bad Request" };
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
