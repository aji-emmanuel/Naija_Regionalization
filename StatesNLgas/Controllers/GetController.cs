using Microsoft.AspNetCore.Mvc;
using StatesNLgas.DataAccess;
using System.Threading.Tasks;

namespace StatesNLgas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;

        public GetController(IDataProvider provider)
        {
            _dataProvider = provider;
        }

        [HttpGet("states")]
        public async Task<IActionResult> States()
        {
            var result = await _dataProvider.GetStatesAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("lgas")]
        public async Task<IActionResult> Lgas()
        {
            var result = await _dataProvider.GetLgasAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("state-lgas")]
        public async Task<IActionResult> StateLgas([FromQuery] string state)
        {
            var result = await _dataProvider.GetStateLgasAsync(state);
            return StatusCode(result.StatusCode, result);
        }
    }
}
