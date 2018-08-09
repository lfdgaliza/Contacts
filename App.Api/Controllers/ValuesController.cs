using App.Domain.Contracts.Service;
using App.Domain.Dto;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMeuService _service;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ValuesController));
        public ValuesController(IMeuService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<RetornoDto> Get()
        {
            _log.Info("Passou pelo Get");
            return _service.RetornarTudo();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public RetornoDto Get(int id)
        {
            _log.Info("Passou pelo Get:id");
            return _service.RetornarAlgo(id);
        }
    }
}
