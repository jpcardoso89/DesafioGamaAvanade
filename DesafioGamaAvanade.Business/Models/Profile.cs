using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models
{
    public class Profile
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Profile(string description)
        {
            Description = description;
        }

        public Profile(Guid id,
                        string description)
        {
            Id = id;
            Description = description;
        }
    }
}
