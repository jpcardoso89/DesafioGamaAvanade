using FluentAssertions;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Models.Inputs;
using DesafioGamaAvanade.Business.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Testes
{
    public class UserServiceTests
    {
        private IUserRepository subUserRepository;
        private IArtistaRepository subArtistaRepository;
        private IProdutorRepository subProdutorRepository;
        private IProfileRepository subProfileRepository;
        private IGeneroRepository subGeneroRepository;
        private UserService userService;
        public UserServiceTests ()
        {
            this.subUserRepository = Substitute.For<IUserRepository>();
            this.subArtistaRepository = Substitute.For<IArtistaRepository>();
            this.subProdutorRepository = Substitute.For<IProdutorRepository>();
            this.subProfileRepository = Substitute.For<IProfileRepository>();
            this.subGeneroRepository = Substitute.For<IGeneroRepository>();
            this.userService = new UserService(subUserRepository,
                subArtistaRepository,
                subProdutorRepository,
                subProfileRepository,
                subGeneroRepository);
        }

        [Theory]
        [InlineData("ARTISTA", "Moabe Renato", 20, 500, "login", "senha", "Ação")]
        [InlineData("", "Moabe Renato", 20, 500, "login", "senha", "Ação")]
        public async void Validar_Inserção_de_Artista(string Role, string Name, int Idade, decimal Cache,
            string Login, string Senha, string genero)
        {
            // Arrange
            var userInput = new UserSaveInput();
            userInput.Login = Login;
            userInput.Password = Senha;
            userInput.Role = Role;
            userInput.Idade = Idade;
            userInput.Cache = Cache;
            userInput.Generos = new List<string>{Guid.NewGuid().ToString()};
            var profile = new Profile(Role);
            var user = new User(Login, Senha, profile);
            var generos = new List<Genero>();
            generos.Add(new Genero(genero));
            var artista = new Artista(Name, Idade,
                                            Cache, new User(Login, Senha, profile),
                                            generos);
            var id = Guid.NewGuid().ToString();
            var generoId = Guid.NewGuid();
            var artistaId = Guid.NewGuid().ToString();
            
            // Gerar os mock
            this.subProfileRepository.GetByRole(Role).Returns(profile);
            this.subUserRepository.InsertAsync(user).Returns(id);
            this.subGeneroRepository.FindById(generoId).Returns(new Genero("Ação"));
            this.subArtistaRepository.Add(artista).Returns(artista);

            // Act
            var result = await this.userService.InsertAsync(userInput).ConfigureAwait(false);

            result.Should().NotBeNull();
        }
    }
}
