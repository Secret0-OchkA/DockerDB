using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.RepositoryPattern;
using Service;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DockerTestBD.Api.Controllers
{
    /// <summary>
    /// Controller for person table
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        readonly IService<Person> service;
        readonly ILogger logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public PersonsController(IService<Person> service, ILogger<PersonsController> logger)
        {
            this.service = service;
            this.logger = logger;

        }
        /// <summary>
        /// GET: api/Persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            logger.LogInformation("GET: api/Persons", DateTime.UtcNow.ToLongTimeString());
            return service.GetAll();
        }

        /// <summary>
        /// GET /api/Persons/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            logger.LogInformation($"GET /api/Persons/{id}", DateTime.UtcNow.ToLongTimeString());
            return service.Get(id);
        }

        /// <summary>
        /// POST api/Persons
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        [HttpPost]
        public async Task<StatusCodeResult> Post([FromQuery, Required] string name, [FromQuery, Required] int age)
        {
            logger.LogInformation($"POST /api/Persons Query:{Request.QueryString}", DateTime.UtcNow.ToLongTimeString());
            service.Insert(new Person { Name = name, Age = age });
            return Ok();
        }

        /// <summary>
        /// PUT api/Persons/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task<StatusCodeResult> Put(int id, [FromBody, Required] Person value)
        {
            Person person = service.Get(id);

            person.Name = value.Name;
            person.Work = value.Work;
            person.Age = value.Age;

            service.Update(person);

            return Ok();
        }

        /// <summary>
        /// DELETE api/Persons/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
