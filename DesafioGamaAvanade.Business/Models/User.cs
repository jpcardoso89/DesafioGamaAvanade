using DesafioGamaAvanade.Business.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string login,
                    string password,
                    Profile profile)
        {
            Login = login;
            CriptografyPassword(password);
            Profile = profile;
            Created = DateTime.Now;
        }

        public User(Guid id,
                Profile profile)
        {
            Id = id;
            Profile = profile;
        }

        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public Profile Profile { get; private set; }
        public DateTime Created { get; set; }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Login) ||
                string.IsNullOrEmpty(Password))
            {
                valid = false;
            }

            return valid;
        }

        public void CriptografyPassword(string password)
        {
            Password = PasswordHasher.Hash(password);
        }

        public bool IsEqualPassword(string password)
        {
            return PasswordHasher.Verify(password, Password);
        }

        public void InformationLoginUser(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void UpdateInfo(string password,
                    Profile profile)
        {
            Profile = profile;

            if (password != Password)
                CriptografyPassword(password);
        }
    }
}
