using hello_world_demo.Model;
using Microsoft.AspNetCore.Mvc;

namespace hello_world_demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Greet : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(GreetResponse), StatusCodes.Status200OK)]
        public ActionResult<GreetResponse> Helloworld()
        {
            var response = new GreetResponse
            {
                Message = "Hello World!"
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult HelloPerson([FromBody] GreetRequest request)
        {
            var response = new GreetResponse
            {
                Message = $"Hello { request.Person }"
            };

            return Ok(response);
        }
    }
}
