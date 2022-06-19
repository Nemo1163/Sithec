using Microsoft.AspNetCore.Mvc;
using sitech.Models;
using sitech.Services.IServices;

namespace sitech.Controllers
{
    public class OperationsMathController : ControllerBase
    {
        private readonly IOperationsMathServices _operationsMathServices;

        public OperationsMathController(IOperationsMathServices operationsMathServices)
        {
            _operationsMathServices = operationsMathServices;
        }

        [Produces("application/json")]
        [Route("~/api/{operationType}/operationsMath")]
        [HttpPost]
        public IActionResult OperationMath([FromRoute] string operationType, [FromBody] OperationsMathModel operationMath)
        {
            return Ok(_operationsMathServices.OperationsMath(operationType, operationMath.NumberOne, operationMath.NumberTwo));
        }

        [Route("~/api/operationsMath")]
        [HttpGet]
        public IActionResult GetOperationMath([FromHeader(Name = "typeoperation")] string typeOperation, [FromHeader(Name = "numberone")] decimal numberOne, [FromHeader(Name = "numbertwo")] decimal numberTwo)
        {
            return Ok(_operationsMathServices.OperationsMath(typeOperation, numberOne, numberTwo));
        }


    }
}
