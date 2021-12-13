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
    [Route("content")]
    public class PageController : ControllerBase
    {
        private readonly ILogger<PageController> _logger;

        public PageController(ILogger<PageController> logger)
        {
            _logger = logger;
        }

        [Route("{num}")]
        [Route("")]
        [HttpGet]
        public IActionResult Index(int num = 0)
        {
            Response.ContentType = "text/html; charset=utf-8";

            string path = new Services.SQL().GetContent(num);

            byte[] fileContent = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(fileContent, "text/html");

        }

    }
}
