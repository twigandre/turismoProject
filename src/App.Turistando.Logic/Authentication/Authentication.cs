using App.Turistando.Utils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Turistando.Logic.Authentication
{
    public class Authentication : IAuthentication
    {
        public UserViewModel Get(string username, string password)
        {
            var users = new List<UserViewModel>
            {
                new(){ Id = 1, Password = "17004395", Role = "maintener", Username = "twig" },
                new(){ Id = 2, Password = "123456789", Role = "user-company", Username = "clturismo" },
                new(){ Id = 3, Password = "987654321", Role = "user", Username = "joao" }
            };
            var filtro = users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            return filtro;
        }
    }
}
