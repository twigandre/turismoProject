using App.Turistando.Database.SqlServer.Entities;
using App.Turistando.Database.SqlServer.Repository;
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
        IRepository<UsuariosCadastradosEntity> _repository;

        public IndexController(ILogger<IndexController>logger,
                               IRepository<UsuariosCadastradosEntity> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public string Get() {
            _logger.LogInformation("*** TURISTANDO service activated in  " + DateTime.UtcNow + " ***");
            return "Turistando! I'm standing :D.";
        }
    }
}
