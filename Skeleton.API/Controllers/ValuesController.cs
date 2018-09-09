using Microsoft.AspNetCore.Mvc;
using Skeleton.Domain.Services;
using System.Collections.Generic;

namespace Skeleton.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _valuesService;
        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _valuesService.GetValues();
        }
    }
}
