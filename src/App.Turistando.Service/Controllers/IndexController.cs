using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<IndexController> _logger;
        public IndexController(ILogger<IndexController>logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get() {
            _logger.LogInformation("SERVIÇO INICIADO EM " + DateTime.UtcNow);
            return "Turistando! I'm standing :D.";
        }
    }
}
