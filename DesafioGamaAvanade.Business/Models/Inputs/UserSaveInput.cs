using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGamaAvanade.Business.Models.Inputs
{
    public class UserSaveInput
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }
        public decimal Cache { get; set; }
        
        // public  Generos { get; set; }
    }
}
