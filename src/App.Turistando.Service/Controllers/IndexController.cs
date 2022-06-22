using App.Turistando.Database.SqlServer.Entities;
using App.Turistando.Database.SqlServer.Repository;
using App.Turistando.Logic.FileUpload;
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
        IFileUpload _uploadFile;

        public IndexController(ILogger<IndexController>logger,
                               IRepository<UsuariosCadastradosEntity> repository,
                               IFileUpload uploadFile)
        {
            _logger = logger;
            _repository = repository;
            _uploadFile = uploadFile;
        }

        [HttpGet]
        public string Get() {
            _logger.LogInformation("*** TURISTANDO service activated in  " + DateTime.UtcNow + " ***");
            return "Turistando! I'm standing :D.";
        }
    }

}
