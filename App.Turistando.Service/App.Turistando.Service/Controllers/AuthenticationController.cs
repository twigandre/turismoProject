using App.Turistando.Logic.Authentication;
using App.Turistando.Logic.Token;
using App.Turistando.Utils.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Turistando.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAuthentication _authentication;
        IToken _token;
        public AuthenticationController(IAuthentication authentication, IToken token)
        {
            _authentication = authentication;
            _token = token;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] UserViewModel model)
        {
            var user = _authentication.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new {status = 404, message = "Usuário e senha Inválidos!"});

            var token = _token.GenerateToken(model);

            return new { status = 200, message = "Usuario encontrado", token = token };
        }


    }
}
