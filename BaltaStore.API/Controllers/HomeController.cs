using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.API.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get() 
        {
            return new { Version =  "Version 0.0.1" };
        }
    }
}