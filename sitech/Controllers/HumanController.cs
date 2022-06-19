using Microsoft.AspNetCore.Mvc;
using sitech.Models;
using sitech.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sitech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        public readonly IHumanServices _humanServices;

        public HumanController(IHumanServices humanServices)
        {
            _humanServices = humanServices;
        }

        [ProducesResponseType(typeof(List<HumanModel>), 200)]
        [Produces("application/json")]
        [Route("~/api/humans/mock")]
        [HttpGet]
        public IActionResult GetListHuman()
        {
            return Ok(_humanServices.GetListHuman());
        }

        [ProducesResponseType(typeof(List<HumanModel>), 200)]
        [Produces("application/json")]
        [Route("~/api/dbhumans")]
        [HttpGet]
        public async Task<IActionResult> GetDBHumans()
        {
            return Ok(await _humanServices.GetDBListHuman());
        }

        [ProducesResponseType(typeof(HumanModel), 200)]
        [Produces("application/json")]
        [Route("~/api/{id:int:min(1)}/dbhuman")]
        [HttpGet]
        public async Task<IActionResult> GetDBHuman([FromRoute] int id)
        {
            return Ok(await _humanServices.GetDBHuman(id));
        }

        [ProducesResponseType(typeof(HumanModel), 200)]
        [Produces("application/json")]
        [Route("~/api/dbhuman")]
        [HttpPost]
        public async Task<IActionResult> PostDBHuman([FromBody] HumanModel humanModel)
        {
            if (humanModel.Id == 0)
            {
                await _humanServices.PostDBHuman(humanModel);
                return Ok(humanModel);
            }

            return BadRequest(new { message = "The Id Must Be 0" });
        }

        [ProducesResponseType(typeof(HumanModel), 200)]
        [Produces("application/json")]
        [Route("~/api/dbhuman")]
        [HttpPut]
        public async Task<IActionResult> PutDBHuman([FromBody] HumanModel humanModel)
        {
            if (humanModel.Id != 0)
            {
                await _humanServices.PutDBHuman(humanModel);
                return Ok(humanModel);
            }
            return BadRequest(new { message = "The Id Must not Be 0" });
        }

    }
}
