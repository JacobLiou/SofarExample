using Microsoft.AspNetCore.Mvc;
using SignalRServer.Hubs;

namespace SignalRServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        [HttpGet]
        public async Task GetMessage()
        {
            
        }

    }
}
