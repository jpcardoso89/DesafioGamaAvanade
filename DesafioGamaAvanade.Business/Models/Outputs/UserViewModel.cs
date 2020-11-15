using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models.Outputs
{
    public class UserViewModel
    {
        public UserViewModel(Guid id,
                                string login,
                                Profile profile,
                                DateTime created)
        {
            Id = id;
            Login = login;
            Profile = profile;
            Created = created;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public Profile Profile { get; set; }
        public DateTime Created { get; set; }
    }
}
