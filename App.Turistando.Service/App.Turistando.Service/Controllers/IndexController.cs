using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Turistando.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {

        public IndexController()
        {
        }

        [HttpGet]
        public string Get() => "Turistando! I'm standing :D.";
    }
}
