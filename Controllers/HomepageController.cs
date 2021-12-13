using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEEEBACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomepageController : ControllerBase
    {
        private readonly ILogger<HomepageController> _logger;

        public HomepageController(ILogger<HomepageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            
            Response.ContentType = "application/json; charset=utf-8";

            string resp = "";

            Models.Header[] headers = new Services.SQL().GetHeaders();

            string head="[ " +( headers.Length == 0 ? "]":"" );
            for (int i = 0; i < headers.Length; i++)
                head += headers[i].ToString() + (i == headers.Length -1 ? " ] " : ", ") ;

            Models.Thing[] news = new Services.SQL().GetHomepageNews();

            string newss = "[ " + (news.Length == 0 ? "]" : "");
            for (int i = 0; i < news.Length; i++)
                newss += news[i].ToString() + (i == news.Length - 1 ? " ] " : ", ");


            resp = "{ \"Header\":"+head+", \"News\" : "+ newss +" }";

            return new JsonResult(resp); 
        }
    }
}
