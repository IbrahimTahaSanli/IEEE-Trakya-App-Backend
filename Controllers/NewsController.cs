using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEEEBACKEND.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        [Route("{num}")]
        [Route("")]
        [HttpGet]
        public ActionResult Index(int num = 0)
        {
            Response.ContentType = "application/json; charset=utf-8";

            Models.Thing[] news = new Services.SQL().GetLatestNews(num);

            string newss = "[ " + (news.Length == 0 ? "]" : "");
            for (int i = 0; i < news.Length; i++)
                newss += news[i].ToString() + (i == news.Length - 1 ? " ] " : ", ");

            return new JsonResult(newss);
        }

    }
}
