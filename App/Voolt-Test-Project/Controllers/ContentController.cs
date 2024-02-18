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
    public class ContentController : Controller
    {
        private readonly IService service;
        public ContentController(
            IService webSiteHeaderService
            )
        {
            this.service = webSiteHeaderService;
        }

        [HttpGet("GetBySectionAndKey")]
        public async Task<IActionResult> Get([FromQuery] string sectionId, [FromQuery] string key)
        {
            try
            {
                return Ok(this.service.Get(sectionId, key));

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
                return Ok(this.service.GetAll());

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
                this.service.Add();
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
                return Ok(this.service.Edit(key, section, model));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string key, [FromQuery] string section)
        {
            try
            {
                this.service.Delete(key, section);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
