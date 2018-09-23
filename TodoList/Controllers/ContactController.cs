using Microsoft.AspNetCore.Mvc;
using TodoList.Web.Models;

namespace TodoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        [HttpGet]
        public Contact Get()
        {
            return new Contact
            {
                Author = "Mateusz Turzyński",
                Email = "mateusz.turzynski@goyello.com",
                Webpage = "https://blog.goyello.com"
            };
        }
    }
}
