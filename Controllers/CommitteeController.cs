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
    [Route("committee")]
    public class CommitteeController : ControllerBase
    {
        private readonly ILogger<CommitteeController> _logger;

        public CommitteeController(ILogger<CommitteeController> logger)
        {
            _logger = logger;
        }

        [Route("{cn}/{num}")]
        [Route("{cn}/")]
        [HttpGet]
        public ActionResult Index(string cn, int num = 0)
        {
            Response.ContentType = "application/json; charset=utf-8";

            Models.Thing[] news = new Services.SQL().GetLatestNewsOfCommittee(cn.ToUpper(),num);

            string newss = "[ " + (news.Length == 0 ? "]" : "");
            for (int i = 0; i < news.Length; i++)
                newss += news[i].ToString() + (i == news.Length - 1 ? " ] " : ", ");

            return new JsonResult(newss);
        }

    }
}
