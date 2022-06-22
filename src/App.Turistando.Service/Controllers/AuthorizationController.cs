using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Turistando.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Estou autenticado");

        [HttpGet]
        [Route("authenticated")]
        [Authorize(Roles = "user-company,maintener")]
        public string TelaEdicao() => "Estou editando";

        [HttpGet]
        [Route("authenticated")]
        [Authorize(Roles = "maintener")]
        public string TelaMantenedor() => "Estou como mantenedor";
    }
}
