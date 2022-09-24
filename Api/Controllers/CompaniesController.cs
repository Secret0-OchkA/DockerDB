using DockerTestBD.Api.Models.EF;
using DockerTestBD.Api.Models.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        readonly ApiContext context;
        readonly ILogger logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public CompaniesController(ApiContext context, ILogger<CompaniesController> logger)
        {
            this.context = context;
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
            return from c in context.Companies.Include(c => c.Workers) select c;
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
            return (from c in context.Companies.Include(c => c.Workers)
                    where c.Id == id
                    select c).FirstOrDefault(new Company());
        }

        /// <summary>
        /// POST api/Companies
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<StatusCodeResult> Post([FromQuery, Required] string value)
        {
            logger.LogInformation($"POST /api/Companies Query:{Request.QueryString}", DateTime.UtcNow.ToLongTimeString());
            Company company = new Company();
            company.Name = value;
            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();
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
            Company? Company = (from c in context.Companies
                              where c.Id == id
                              select c).FirstOrDefault();


            if (Company == null)
            {
                logger.LogWarning($"PUT api/Companies/{id} NotFound body:{JsonConvert.SerializeObject(value)}", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }

            Company.Name = value.Name;
            Company.Workers = value.Workers;

            await context.SaveChangesAsync();

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
            Company? Company = (from c in context.Companies
                              where c.Id == id
                              select c).FirstOrDefault();

            if (Company == null)
            {
                logger.LogWarning($"DELETE api/Companies/{id} NotFound", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }

            context.Companies.Remove(Company);
            await context.SaveChangesAsync();
            logger.LogInformation($"DELETE api/Companies/{id}", DateTime.UtcNow.ToLongTimeString());
            return Ok();
        }
    }
}
