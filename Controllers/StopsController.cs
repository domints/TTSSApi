using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTSSApi.Web.Abstraction.Services;
using TTSSApi.Web.Models.API;

namespace TTSSApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StopsController : ControllerBase
    {
        private readonly IStopService _stopService;

        public StopsController(IStopService stopService)
        {
            _stopService = stopService;
        }
        public Task<IReadOnlyCollection<StopBase>> Autocomplete(string q)
        {
            return _stopService.GetAutocomplete(q);
        }

        [HttpGet]
        [Route("passages")]
        public async Task<IEnumerable<object>> Passages(int stopId)
        {
            return Enumerable.Empty<object>();
        }
    }
}