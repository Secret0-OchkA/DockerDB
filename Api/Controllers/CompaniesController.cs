using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.RepositoryPattern;
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
        readonly IRepository<Company> repository;
        readonly ILogger logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public CompaniesController(IRepository<Company> repository, ILogger<CompaniesController> logger)
        {
            this.repository = repository;
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
            return repository.GetAll();
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
            return repository.Get(id);
        }

        /// <summary>
        /// POST api/Companies
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<StatusCodeResult> Post([FromQuery, Required] string value)
        {
            logger.LogInformation($"POST /api/Companies Query:{Request.QueryString}", DateTime.UtcNow.ToLongTimeString());
            repository.Insert(new Company { Name = value });
            repository.SaveChanges();
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
            Company company = repository.Get(id);

            company.Name = value.Name;
            company.Workers = value.Workers;

            repository.Update(company);
            repository.SaveChanges();

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
            Company? Company = repository.Get(id);

            repository.Delete(Company);

            logger.LogInformation($"DELETE api/Companies/{id}", DateTime.UtcNow.ToLongTimeString());
            return Ok();
        }
    }
}
