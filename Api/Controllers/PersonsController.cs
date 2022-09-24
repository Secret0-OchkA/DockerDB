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
    /// Controller for person table
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        readonly ApiContext context;
        readonly ILogger logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public PersonsController(ApiContext context, ILogger<PersonsController> logger)
        {
            this.context = context;
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
            return from p in context.Persons.Include(p => p.Work) select p;
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
            return (from p in context.Persons.Include(p => p.Work)
                    where p.Id == id
                    select p).FirstOrDefault(new Person());
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
            Person person = new Person();

            person.Name = name;
            person.Age = age;

            await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();
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
            Person? person = (from p in context.Persons
                              where p.Id == id
                              select p).FirstOrDefault();
            

            if (person == null)
            {
                logger.LogWarning($"PUT api/Persons/{id} NotFound body:{JsonConvert.SerializeObject(value)}", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }

            person.Name = value.Name;
            person.Work = value.Work;

            await context.SaveChangesAsync();

            logger.LogInformation($"PUT api/Persons/{id} body:{JsonConvert.SerializeObject(value)}", DateTime.UtcNow.ToLongTimeString());
            return Ok();
        }

        /// <summary>
        /// DELETE api/Persons/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(int id)
        {
            Person? person = (from p in context.Persons
                              where p.Id == id
                              select p).FirstOrDefault();

            if (person == null)
            {
                logger.LogWarning($"DELETE api/Persons/{id} NotFound", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }

            context.Persons.Remove(person);
            await context.SaveChangesAsync();
            logger.LogInformation($"DELETE api/Persons/{id}", DateTime.UtcNow.ToLongTimeString());
            return Ok();
        }
    }
}
