using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ShowsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://jsnoise.herokuapp.com/api/showslist");
            return Ok(await result.Content.ReadAsStringAsync());
        }
    }
}