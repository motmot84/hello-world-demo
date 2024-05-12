using Microsoft.AspNetCore.Mvc;
using hello_world_demo.Model;
using hello_world_demo.Model.AutoMapper;
using Newtonsoft.Json;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace hello_world_demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatoController : ControllerBase
    {
        private IMapper _mapper;
        public GatoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cats = JsonConvert.DeserializeObject<Gato[]>(System.IO.File.ReadAllText("raw-cat.json"));
            
            var catsDto = _mapper.Map<GatoDto[]>(cats);
            var rawString = JsonConvert.SerializeObject(catsDto, Formatting.Indented, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver()});
            System.IO.File.WriteAllText("cat.json", rawString);

            return Ok("Meow");
        }
    }
}