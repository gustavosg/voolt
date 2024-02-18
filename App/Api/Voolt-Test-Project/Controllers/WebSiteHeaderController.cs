using Domain;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Services;
using System.Net;

namespace Voolt_Test_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSiteHeaderController : Controller
    {
        private readonly IService webSiteHeaderService;
        public WebSiteHeaderController(
            IService webSiteHeaderService
            )
        {
            this.webSiteHeaderService = webSiteHeaderService;
        }

        [HttpGet("key")]
        public async Task<IActionResult> Get(string key)
        {
            try
            {
                return Ok(this.webSiteHeaderService.Get(key));

            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(this.webSiteHeaderService.GetAll());

            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            try
            {
                this.webSiteHeaderService.Add();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery]string key, [FromQuery] string section, [FromBody] Object model)
        {
            try
            {                
                return Ok(this.webSiteHeaderService.Edit(key, section, model));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
