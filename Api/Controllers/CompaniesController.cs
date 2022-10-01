using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DockerTestBD.Api.Controllers
{
    /// <summary>
    /// Controller for Company table
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        readonly IService<Company> service;
        readonly ILogger logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public CompaniesController(IService<Company> service, ILogger<CompaniesController> logger)
        {
            this.service = service;
            this.logger = logger;
        }
        /// <summary>
        /// GET: api/Companies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            logger.LogInformation("GET: api/Companies", DateTime.UtcNow.ToLongTimeString());
            return service.GetAll();
        }

        /// <summary>
        /// GET /api/Companies/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            logger.LogInformation($"GET /api/Companies/{id}", DateTime.UtcNow.ToLongTimeString());
            return service.Get(id);
        }

        /// <summary>
        /// POST api/Companies
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<StatusCodeResult> Post([FromQuery, Required] string value)
        {
            logger.LogInformation($"POST /api/Companies Query:{Request.QueryString}", DateTime.UtcNow.ToLongTimeString());
            service.Insert(new Company { Name = value });
            return Ok();
        }

        /// <summary>
        /// PUT api/Companies/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task<StatusCodeResult> Put(int id, [FromBody, Required] Company value)
        {
            Company company = service.Get(id);

            company.Name = value.Name;
            company.Workers = value.Workers;

            service.Update(company);

            logger.LogInformation($"PUT api/Companies/{id} body:{JsonConvert.SerializeObject(value)}", DateTime.UtcNow.ToLongTimeString());
            return Ok();
        }

        /// <summary>
        /// DELETE api/Companies/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(int id)
        {
            service.Delete(id);

            logger.LogInformation($"DELETE api/Companies/{id}", DateTime.UtcNow.ToLongTimeString());
            return Ok();
        }
    }
}
